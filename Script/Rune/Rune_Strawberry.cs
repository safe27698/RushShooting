using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_Strawberry : Player_Rune {


	public override void AbilityRune ()
	{
		base.AbilityRune ();
		playermodel.m_Speed += 2;
	}
}
