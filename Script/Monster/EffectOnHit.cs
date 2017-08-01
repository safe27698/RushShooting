using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyEffect ()
	{
		PoolManager.ReleaseObject (this.gameObject);
	}
}
