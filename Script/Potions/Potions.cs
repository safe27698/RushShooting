using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour {
	protected PlayerModel pm;

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			pm = other.gameObject.GetComponent<PlayerModel> ();
			Ability ();
			PoolManager.ReleaseObject (this.gameObject);
		}
	}

	public virtual void Ability ()
	{
		
	}

}
