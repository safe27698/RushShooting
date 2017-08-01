using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : ScriptableObject {


	public GameObject gunPlyer;
	public GameObject runePlayer;

	public List<GameObject> obj;
	public List<GameObject> m_boj 
	{
		get
		{ return obj; }
		set
		{obj = value; }
	}
}
