using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Monster : Bullet {


	public void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
		
			MonsterManager.MonsterDamage.Invoke (damage);
		
		}
	}
}
