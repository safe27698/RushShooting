using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {
	public SaveData saveData;
	[Space]

	[SerializeField]
	private int gold;
	public int m_Gold 
	{
		get{return gold = saveData.gold;}
		set
		{ 
			gold = value; 
			saveData.gold = gold;
			text_Gold.text = ""+gold;
		}
	}
	public Text text_Gold;
	[Space]

	[SerializeField]
	private int diamond;
	public int m_Diamond 
	{
		get{return diamond = saveData.diamond;}
		set
		{ 
			diamond = value; 
			saveData.diamond = diamond;
			text_Diamond.text = ""+diamond;
		}
	}
	public Text text_Diamond;
	[Space]

	[SerializeField]
	private int energy;
	public int m_Energy 
	{
		get{return energy = saveData.energy;}
		set
		{ 
			energy = value; 
			saveData.energy = energy;
			text_Energy.text = ""+energy;
		}
	}
	public Text text_Energy;
	[Space]


//	public List<GameObject> myGun = new List<GameObject>();
//	[HideInInspector]
//	public List<GameObject> myRune =  new List<GameObject> ();
//	[Space]


	public Image gunSelection ;
	public Image runeSelection;

	public Text gunAbilityText;
	public Text runeAbilityText;

	public GameObject cantBuy;

	private Gun gun;
	private int gunSpot = 0;

	private Player_Rune rune;
	private int runeSpot = 0;



	public void Awake ()
	{
		text_Gold.text = ""+ saveData.gold;
		text_Diamond.text = ""+ saveData.diamond;
		text_Energy.text = ""+ saveData.energy;

		UI_Manager.DataChangeEvent.AddListener (UI_Update);
	}

	public void OpenButton (GameObject g)
	{
		g.SetActive (true);
//		StartCoroutine (WaitSec(g,true));
	}

	public void ExitButton (GameObject s)
	{
//		s.SetActive (false);
		//print("eiei");	
		StartCoroutine (WaitSec(s));
	}

	public IEnumerator WaitSec (GameObject s)
	{
		//print ("Begin");
		yield return new WaitForSecondsRealtime (1f);
		//print (s);
		s.SetActive (false);
		//Debug.Log ("end");
	}


	public void Disable (Button b)
	{
		b.interactable = false;
		StartCoroutine (Enable(b));

	}

	IEnumerator Enable (Button b)
	{
		yield return new WaitForSeconds (1);
		b.interactable = true;
	}



	public void BuyGold (int i)
	{

		UI_Manager.AddGold.Invoke(i);
	}

	public void BuyDiamond (int i)
	{
//		m_Diamond += i;
		UI_Manager.AddDiamond.Invoke(i);
	}

	public void BuyEnergy (int i)
	{
//		m_Energy += i;
		UI_Manager.AddEnergy.Invoke(i);
	}
 

	public void BuyGun_Gold (GameObject g)
	{
		gun = g.GetComponent<Gun> ();
		if (m_Gold >= gun.priceGun) {
//			m_Gold -= gun.priceGun;
//			saveData.allGun.Add (g);
			UI_Manager.SetUserData.Invoke(g.name);
			UI_Manager.Bought.Invoke (g.gameObject.name);
			UI_Manager.SubtractGold.Invoke (gun.priceGun);
		} 
		else {
		
			CantBuy ();
		}

	}

	public void BuyGun_Diamond (GameObject g)
	{
		gun = g.GetComponent<Gun> ();
		if (m_Diamond >= gun.priceGun) {
			//			m_Gold -= gun.priceGun;
//			saveData.allGun.Add (g);
			UI_Manager.SetUserData.Invoke(g.name);
			UI_Manager.Bought.Invoke (g.gameObject.name);
			UI_Manager.SubtractGold.Invoke (gun.priceGun);
		} 
		else {

			CantBuy ();
		}

	}

	public void BuyRune_Gold (GameObject g)
	{
		rune = g.GetComponent<Player_Rune> ();
		if (m_Gold >= rune.priceRune) {
//			m_Gold -= rune.priceRune;
//			saveData.allRune.Add(g);
			UI_Manager.SetUserData.Invoke(g.name);
			UI_Manager.Bought.Invoke (g.gameObject.name);
			UI_Manager.SubtractGold.Invoke (rune.priceRune);
		} 
		else {

			CantBuy ();
		}

	}

	public void BuyRune_Diamond (GameObject g)
	{
		rune = g.GetComponent<Player_Rune> ();
		if (m_Diamond >= rune.priceRune) {
			//			m_Gold -= rune.priceRune;
//			saveData.allRune.Add(g);
			UI_Manager.SetUserData.Invoke(g.name);
			UI_Manager.Bought.Invoke (g.gameObject.name);
			UI_Manager.SubtractDiamond.Invoke (rune.priceRune);
		} 
		else {

			CantBuy ();
		}

	}


		
	public void CantBuy ()
	{
		cantBuy.SetActive (true);
		StartCoroutine (CantBuy_());
	}

	IEnumerator CantBuy_ ()
	{
		yield return new WaitForSeconds (1);
		cantBuy.SetActive (false);
	}

	public void DiableButton (Button g)
	{
		g.interactable = false;
	}
		
	public void SelectItem ()
	{

		gun = saveData.allGun [0].GetComponent<Gun> ();
		gunSelection.sprite = gun.gunImage;
		gunAbilityText.text = gun.abilityGun;

		rune = saveData.allRune [0].GetComponent<Player_Rune> ();
		runeSelection.sprite = rune.runeImage;
		runeAbilityText.text = rune.abilityRune;

		saveData.gunPlyer = saveData.allGun [0];
		saveData.runePlayer = saveData.allRune [0];

	
	}
	public void LeftSelection (string c)
	{

		if(c == "Gun")
		{
			if (gunSpot > 0) {

				gunSpot--;
				gun = saveData.allGun [gunSpot].GetComponent<Gun> ();
				gunSelection.sprite = gun.gunImage;
				gunAbilityText.text = gun.abilityGun;
				saveData.gunPlyer = saveData.allGun [gunSpot];
			}

		}
		if(c == "Rune")
		{
			if (runeSpot > 0) {

				runeSpot--;
				rune = saveData.allRune [runeSpot].GetComponent<Player_Rune> ();
				runeSelection.sprite = rune.runeImage;
				runeAbilityText.text = rune.abilityRune;
				saveData.runePlayer = saveData.allRune [runeSpot];
			}

		}

	}

	public void RightSelection (string c)
	{

		if(c == "Gun")
		{
			if (gunSpot < saveData.allGun.Count-1) {

				gunSpot++;
				gun = saveData.allGun [gunSpot].GetComponent<Gun> ();
				gunSelection.sprite = gun.gunImage;
				gunAbilityText.text = gun.abilityGun;
				saveData.gunPlyer = saveData.allGun [gunSpot];
			}
		}

		if(c == "Rune")
		{
			if (runeSpot < saveData.allRune.Count-1) {

				runeSpot++;
				rune = saveData.allRune [runeSpot].GetComponent<Player_Rune> ();
				runeSelection.sprite = rune.runeImage;
				runeAbilityText.text = rune.abilityRune;
				saveData.runePlayer = saveData.allRune [runeSpot];
			}

		}

	}

	public void CurrectState (CheckState i)
	{
		int c = i.GetComponent<CheckState> ().currentState;
		saveData.state = c;
	}


	public void UI_Update (GameModel.GameData data)
	{
		m_Gold = data.gold;
		m_Diamond = data.diamond;
		m_Energy = data.energy;
	}

}
