using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;

public class SaveData : ScriptableObject {

	public List<GameObject> allGun = new List<GameObject> ();
	public List<GameObject> allRune = new List<GameObject> ();
	[Space]
	public GameObject gunPlyer;
	public GameObject runePlayer;
	[Space]
	public int gold;
	public int diamond;
	public int energy;

	[Space]
	public int goldReceived;
	public int diamondUsed;
	[Space]
	public int state ;
//	public int[] timer  ;
//	public bool[] completeState;
	public List<int> timer = new List<int> ();
	public List<bool> completeState = new List<bool> ();

	[Space]
	public int numOfMonster;
	public int numOfBoss;
	public int levelMonster;
	public string map;
	[Space]
	public string nameUser;

}
