using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : Bullet {

	public void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Monster") {

			PlayerManager.PlayerDamage.Invoke (other.gameObject,damage);
		}
	}
}
