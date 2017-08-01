using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetGame : MonoBehaviour {

	public SaveData data;
	public Button btn;

	[Space]
	public int numOfMon;
	public int numOfBoss;
	public int lvMon;
	public string map;

	public void Awake ()
	{
		btn = btn.GetComponent<Button> ();
		btn.onClick.AddListener (() => SetState(numOfMon,numOfBoss,lvMon,map) );
	}

	public void SetState (int mon, int boss, int lv, string m)
	{
		data.numOfMonster = mon;
		data.numOfBoss = boss;
		data.levelMonster = lv;
		data.map = m;
	}

}
