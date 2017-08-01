using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack_Range : MonsterStateAttack {

	public GameObject bullet;
	Transform posiBullet;
	static bool createBul = false;
	void Start ()
	{
		posiBullet = transform.GetChild (0).gameObject.GetComponent<Transform>();
		if (createBul == false) {
			PoolManager.WarmPool (bullet,25);
			createBul = true;
		}

	}

	public override void Attack ()
	{
		base.Attack ();
		transform.LookAt (monsterModel.myTarget.transform);
		Bullet bull = PoolManager.SpawnObject (bullet,posiBullet.position,posiBullet.rotation).GetComponent<Bullet>();
		bull.DirectFire (transform.forward,"Monster",monsterModel.MyDamge);

	}
}
