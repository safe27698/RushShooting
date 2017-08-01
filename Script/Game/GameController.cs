using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;


public class GameController : MonoBehaviour {

	GameModel gm;

	void Awake ()
	{
		gm = gameObject.GetComponent<GameModel> ();

		UI_Manager.AddGold.AddListener (AddGold);
		UI_Manager.AddDiamond.AddListener (AddDiamond);
		UI_Manager.AddEnergy.AddListener (AddEnergy);

		UI_Manager.SubtractGold.AddListener (SubtractGold);
		UI_Manager.SubtractDiamond.AddListener (SubtractDiamond);
		UI_Manager.SubtractEnergy.AddListener (SubtractEnergy);
	}


	public void LoadData ()
	{
		gm.Load ();
	}

	public void AddGold (int g)
	{
		gm.AddCurrency ("GO",g);
	}

	public void AddDiamond (int g)
	{
		gm.AddCurrency ("DI",g);
	}

	public void AddEnergy (int g)
	{
		gm.AddCurrency ("EN",g);
	}

	public void SubtractGold (int g)
	{
		gm.SubtractCurrency ("GO",g);
	}

	public void SubtractDiamond (int g)
	{
		gm.SubtractCurrency ("DI",g);
	}

	public void SubtractEnergy ()
	{
		gm.SubtractCurrency ("EN",1);
	}
}
