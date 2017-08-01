using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack_Melee : MonsterStateAttack {


	public override void Attack ()
	{
		base.Attack ();
		MonsterManager.MonsterDamage.Invoke (monsterModel.MyDamge);
	}
}
