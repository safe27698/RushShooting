using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Hearth : Potions {

	public override void Ability ()
	{
		base.Ability ();
		pm.m_Hp += 50;
	}
}
