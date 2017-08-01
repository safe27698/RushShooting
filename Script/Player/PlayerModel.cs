using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

	[HideInInspector]
	public float hor,ver,shootingHor,shootingVer;
	[HideInInspector]
	public Rigidbody rigid;
	[HideInInspector]
	public	Animator ani;
	[HideInInspector]
	public PlayerManager playerManager;
	[HideInInspector]
	public GameObject gun;
	public Gun myGun;

	public GameObject rune;
	public Player_Rune myRune;

	public SaveData saveData;

	private PlayerController pc;

	[SerializeField]
	private float speed ;
	public float m_Speed
	{
		get{ return speed; }
		set{ speed = value; }
	}

	[SerializeField]
	private float hp ;
	public float m_Hp
	{
		get{ return hp; }
		set
		{ 
			hp = value;
			if (hp >= 100) {
			
				hp = 100;
			
			}
			UI_Manager.Hp.Invoke (hp);

		}
	}
		


	void Awake()
	{
		rigid = gameObject.GetComponent<Rigidbody> ();
		ani = gameObject.GetComponent<Animator> ();
		pc = gameObject.GetComponent<PlayerController> ();

		playerManager = GameObject.Find("PlayerManager").gameObject.GetComponent<PlayerManager>() ;



		gun = saveData.gunPlyer;
		Transform p = GameObject.Find ("PositionGunPlayer").GetComponent<Transform>();
		GameObject g  = Instantiate (gun,p.position,p.rotation);
		g.transform.parent = GameObject.Find ("PositionGunPlayer").transform;
		myGun = g.GetComponent<Gun> ();

		rune = saveData.runePlayer;
		myRune = rune.GetComponent<Player_Rune> ();
		GameObject r = Instantiate (rune,transform.position+new Vector3 (0,1,0),Quaternion.Euler(new Vector3(-90,0,0)) );
		r.transform.parent = GameObject.FindGameObjectWithTag ("Player").transform;
		myRune.CheckRune (this.gameObject);
	}

	void Start()
	{

	}



}
