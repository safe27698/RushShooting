using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	public string nameGun  ;
	public Sprite gunImage;
	public GameObject bullet;
	[SerializeField]
	private float fireRate = 0 ;
	private float LastFire;

	public string abilityGun;

	public int priceGun;
	public int damage;


	private Transform positionGunPlayer;


	public void Awake ()
	{
		nameGun = gameObject.name;
	}
	void Start ()
	{
		PoolManager.WarmPool (bullet,30);
		positionGunPlayer = GameObject.Find ("PositionGunPlayer").GetComponent<Transform>();
	}

	public void Shooting (Vector3 d)
	{
		
		if(Time.time > LastFire+fireRate)
		{
			Bullet b = PoolManager.SpawnObject (bullet,positionGunPlayer.position+new Vector3 (0,0,0),positionGunPlayer.rotation).GetComponent<Bullet>();
			b.DirectFire ( d,"Player",damage);
			LastFire = Time.time;
		}
	}


}
