using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BuyCurrency : MonoBehaviour {

	public SaveData data ;
	public Button btn;
	public GameObject buySuccess;
	public GameObject cantBuy;

	[Space]
	public int amountUsed;
	public int amountReceived;
	public string typeCurrency;

	public void Awake ()
	{
		btn = btn.GetComponent<Button> ();
		btn.onClick.AddListener (() => Buy(amountUsed,amountReceived,typeCurrency));
	}

	public void Buy (int u, int r, string t)
	{
		if(t == "gold")
		{
			if (data.diamond < u) {
				cantBuy.SetActive (true);
				StartCoroutine (CantBuyCurrency ());
			} 
			else 
			{
				UI_Manager.SubtractDiamond.Invoke (u);
				UI_Manager.AddGold.Invoke (r);
				buySuccess.SetActive (true);
				StartCoroutine (BuySuccessfully());
			}
		}
		else if(t == "energy")
		{
			if (data.diamond < u) {
				cantBuy.SetActive (true);
				StartCoroutine (CantBuyCurrency ());
			} 
			else 
			{
				UI_Manager.SubtractDiamond.Invoke (u);
				UI_Manager.AddEnergy.Invoke (r);
				buySuccess.SetActive (true);
				StartCoroutine (BuySuccessfully());
			}
		}
	}
	IEnumerator CantBuyCurrency ()
	{
		yield return new WaitForSeconds (1);
		cantBuy.SetActive (false);
	}
	IEnumerator BuySuccessfully ()
	{
		yield return new WaitForSeconds (1);
		buySuccess.SetActive (false);
	}
}
