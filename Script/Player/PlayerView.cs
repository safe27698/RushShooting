using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerView : MonoBehaviour {
	
	private PlayerModel playermodel;

	void Awake()
	{
		playermodel = gameObject.GetComponent<PlayerModel>();
	}


	void Start () {
		
	}

	void FixedUpdate()
	{

		playermodel.shootingHor = CrossPlatformInputManager.GetAxis ("ShootingHorizontal");
		playermodel.shootingVer = CrossPlatformInputManager.GetAxis ("ShootingVertical");
	
		playermodel.hor = CrossPlatformInputManager.GetAxis ("Horizontal");
		playermodel.ver = CrossPlatformInputManager.GetAxis ("Vertical");
//		playermodel.hor = Input.GetAxis ("Horizontal");
//		playermodel.ver = Input.GetAxis ("Vertical");
//
	
	}
	void Update () {
		
	}



}
