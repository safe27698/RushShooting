using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_Grape : Player_Rune {


	public override void AbilityRune ()
	{
		base.AbilityRune ();
		playermodel.myGun.damage += 10;
	}
}
