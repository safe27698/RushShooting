using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;

public class Main_Game_Manager : MonoBehaviour {

	public SaveData data;

	public List<GameObject> allGunInGame = new List<GameObject>() ;
	public List<GameObject> allRuneInGame = new List<GameObject>();

	public void Awake ()
	{
		UI_Manager.SetUserData.AddListener (SetUserData);
		UI_Manager.GetUserData.AddListener (GetUserData);
	}

	public void Start ()
	{

	}

	public void SetUserData(string nameGun)
	{
		UpdateUserDataRequest request = new UpdateUserDataRequest()
		{
			Data = new Dictionary<string, string>(){
				{ nameGun , "T" }
			}
				
		};

		PlayFabClientAPI.UpdateUserData(request, (result) =>
			{
				Debug.Log("Successfully updated user data");
			}, (error) =>
			{
				Debug.Log("Got error setting user data Ancestor to Arthur");
				Debug.Log(error.ErrorDetails);
			});
		StartCoroutine(repeat());
	}

	public void GetUserData()
	{
		GetUserDataRequest request = new GetUserDataRequest()
		{

		};

		PlayFabClientAPI.GetUserData(request,(result) => {
			Debug.Log("Got user data:");
			if ((result.Data == null) || (result.Data.Count == 0))
			{
				Debug.Log("No user data available");
				StartCoroutine(repeat());
			}
			else
			{
				data.allGun.Clear();
				data.allRune.Clear();
				foreach (var item in result.Data)
				{
					Debug.Log("    " + item.Key + " == " + item.Value.Value);
//					data.allGun.Clear();
					foreach (GameObject m in allGunInGame)
					{
						if(m.gameObject.name == item.Key)
						{
							data.allGun.Add(m.gameObject);
						}
					}
					foreach (GameObject m in allRuneInGame)
					{
						if(m.gameObject.name == item.Key)
						{
							data.allRune.Add(m.gameObject);
						}
					}
				}


			}
		}, (error) => {
			Debug.Log("Got error retrieving user data:");
			Debug.Log(error.ErrorMessage);
		});
	}

	IEnumerator repeat ()
	{
		yield return new WaitForSeconds (1);
		GetUserData ();
		yield return new WaitForSeconds (2);
		GetUserData ();
		yield return new WaitForSeconds (3);
		GetUserData ();
	}


	public void ExitGame ()
	{
		Application.Quit ();
	}

}
