using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Rune : MonoBehaviour {

	protected PlayerModel playermodel;


	public Sprite runeImage;
	public int priceRune;

	public string abilityRune;

	public void Awake ()
	{

	}

	public void Start ()
	{

	}

	public  void CheckRune (GameObject p)
	{
		playermodel = p.gameObject.GetComponent<PlayerModel>();
		if(playermodel.rune.name == this.gameObject.name)
		AbilityRune ();
	}

	public virtual void AbilityRune ()
	{
		
	}
}
