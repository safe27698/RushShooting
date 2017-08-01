using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	protected float damage;
	protected string myBullet;

	Vector3 directFire;

	void OnEnable ()
	{
		if (isActiveAndEnabled) {
		
			StartCoroutine ("Destroy");
		}
	}

	public void DirectFire (Vector3 direct,string name,float dam)
	{
		directFire = direct;
		myBullet = name;
		damage = dam;

	}

	void FixedUpdate()
	{
		Vector3 direct = directFire.normalized;
		Vector3 velocity = direct * speed * Time.deltaTime;
		transform.position = transform.position + velocity;

	}


	IEnumerator Destroy ()
	{
		yield return new WaitForSeconds (1f);
		PoolManager.ReleaseObject (this.gameObject);
	}
}
