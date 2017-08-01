using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;

public class GameView : MonoBehaviour {


	// INSPECTOR TWEAKABLES
	GameModel gm;
	private static GameView instance;
	public string playFabTitleId = string.Empty;
	public RawImage profilePic;
	public Text nameUser;

	public UnityEvent GetInventoryEvents = new UnityEvent();

	void Awake()
	{            
		gm = gameObject.GetComponent<GameModel> ();
		//DontDestroyOnLoad(gameObject);
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		if (!FB.IsInitialized)
		{
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		}
		else
		{
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}

		GetInventoryEvents.AddListener(GetComponent<GameController>().LoadData);
	}

	private void InitCallback()
	{
		if (FB.IsInitialized)
		{
			// Signal an app activation App Event
			FB.ActivateApp();
			Time.timeScale = 0;
			// Continue with Facebook SDK
			// ...
			var perms = new List<string>() { "public_profile", "email", "user_friends" };
			FB.LogInWithReadPermissions(perms, AuthCallBack);
		}
		else
		{
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void AuthCallBack(Facebook.Unity.ILoginResult result)
	{
		if (FB.IsLoggedIn)
		{
			// AccessToken class will have session details
			var aToken = AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions)
			{
				Debug.Log(perm);
			}

			LoginWithFacebook(aToken.TokenString, true, null);
		}
		else
		{
			Debug.Log("User cancelled login");
		}
	}

	public void LoginWithFacebook(string token, bool createAccount = false, UnityAction errCallback = null)
	{
		//LoginMethodUsed = LoginPathways.facebook;
		LoginWithFacebookRequest request = new LoginWithFacebookRequest();
		request.AccessToken = token;
		request.TitleId = PlayFabSettings.TitleId;
		request.CreateAccount = createAccount;

		PlayFabClientAPI.LoginWithFacebook(request, OnLoginCB, OnApiCallError);
	}

	void OnLoginCB(PlayFab.ClientModels.LoginResult result)
	{
		Debug.Log(string.Format("Login Successful. Welcome Player:{0}!", result.PlayFabId));
		Debug.Log(string.Format("Your session ticket is: {0}", result.SessionTicket));
		FB.API("/me?fields=first_name", HttpMethod.GET, updatePlayFabUserTitleDisplayName);
		FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, FbGetPicture);

		GetInventoryEvents.Invoke();
		UI_Manager.SetUserData.Invoke ("Weapon_1");
//		PlayEvents.Invoke();

		OnHideUnity(true); 
	}

	private void FbGetPicture(IGraphResult result)
	{
		if (result.Texture != null && profilePic != null) {
			profilePic.texture = result.Texture;
		}
			
	}

	private void updatePlayFabUserTitleDisplayName(IGraphResult result)
	{

		string fbname = result.ResultDictionary["first_name"] as string;
		Debug.Log("your name is: " + fbname);
		if (nameUser != null)
			nameUser.text = fbname;

		PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = fbname }, null, null);

	}

	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		}
		else
		{
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	void OnApiCallError(PlayFabError err)
	{
		string http = string.Format("HTTP:{0}", err.HttpCode);
		string message = string.Format("ERROR:{0} -- {1}", err.Error, err.ErrorMessage);
		string details = string.Empty;

		if (err.ErrorDetails != null)
		{
			foreach (var detail in err.ErrorDetails)
			{
				details += string.Format("{0} \n", detail.ToString());
			}
		}

		Debug.LogError(string.Format("{0}\n {1}\n {2}\n", http, message, details));
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


		
}
