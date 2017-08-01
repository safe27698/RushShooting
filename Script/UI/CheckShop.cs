using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckShop : MonoBehaviour {

	public SaveData saveData;
	public GameObject item;
	public Button button;

	public void Awake ()
	{
		UI_Manager.Bought.AddListener (Bought);
	}

	public void OnEnable ()
	{
		foreach(GameObject m in saveData.allGun)
		{
			if(item.name == m.name)
			{
				button.interactable = false;
			}
		}
		foreach(GameObject m in saveData.allRune)
		{
			if(item.name == m.name)
			{
				button.interactable = false;
			}
		}
	}


	public void Bought (string t)
	{
		if(this.gameObject.name == t)
		{
			button.interactable = false;
		}

	}

}
