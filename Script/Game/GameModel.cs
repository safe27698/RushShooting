using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;


public class GameModel : MonoBehaviour {
	const string goldCode = "GO";
	const string diamondCode = "DI";
	const string energyCode = "EN";




	public SaveData data;

	GameData _gameData = new GameData();
	public class GameData
	{
		public int gold = 0;
		public int diamond = 0;
		public int energy = 0;
		public int energyMax = -1;
		public int rechargeEnergyTime = -1;
	}


	public void Start ()
	{

	}

	public void OnEnable ()
	{
		if(data.goldReceived != 0)
		{
			UI_Manager.AddGold.Invoke (data.goldReceived);
			data.goldReceived = 0;
		}
		if(data.diamondUsed != 0)
		{
			UI_Manager.SubtractDiamond.Invoke (data.diamondUsed);
			data.diamondUsed = 0;
		}

	}
	public void Load ()
	{
		GetUserInventoryRequest request = new GetUserInventoryRequest();
		PlayFabClientAPI.GetUserInventory(request, OnGetInventoryCallback, OnApiCallError);  
	}

	public GameData gameData 
	{
		get
		{
			return _gameData;
		}
		set
		{
			_gameData = value;
			UI_Manager.DataChangeEvent.Invoke (_gameData);
		}
	}

	private void OnGetInventoryCallback(GetUserInventoryResult result)
	{
		Debug.Log(string.Format("Inventory retrieved. You have {0} items.", result.Inventory.Count));

		int goldBalance;
		result.VirtualCurrency.TryGetValue(goldCode, out goldBalance);               

		int diamondBalance;
		result.VirtualCurrency.TryGetValue(diamondCode, out diamondBalance);

		int energyBalance;
		result.VirtualCurrency.TryGetValue (energyCode, out energyBalance);

		VirtualCurrencyRechargeTime rechargeDetails;
		result.VirtualCurrencyRechargeTimes.TryGetValue(energyCode, out rechargeDetails);

		gameData = (rechargeDetails != null) ?
			new GameData ()
		{
			gold = goldBalance,
			diamond = diamondBalance,
			energy = energyBalance,
			rechargeEnergyTime = rechargeDetails.SecondsToRecharge,
			energyMax = rechargeDetails.RechargeMax
		} :
			new GameData () 
		{
			gold = goldBalance,
			diamond = diamondBalance,
			energy = energyBalance
		};   

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

	public void AddCurrency (string c ,int g)
	{
		ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest()
		{

			FunctionName = "AddCurrency",
			FunctionParameter = new Dictionary<string, object> { { "codeCur", c },{"cur",g}}
		};

		PlayFabClientAPI.ExecuteCloudScript(request, SubtractCallback, OnApiCallError);
	}

	public void SubtractCurrency (string c ,int g)
	{
		ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest()
		{

			FunctionName = "SubtractCurrency",
			FunctionParameter = new Dictionary<string, object> { { "codeCur", c },{"cur",g}}
		};

		PlayFabClientAPI.ExecuteCloudScript(request, SubtractCallback, OnApiCallError);
	}



	void SubtractCallback(ExecuteCloudScriptResult result)
	{
		// output any errors that happend within cloud script
		if (result.Error != null)
		{
			Debug.LogError(string.Format("{0} -- {1}", result.Error, result.Error.Message));
			return;
		}

		Load();

	}


}
