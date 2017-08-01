using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class MonsterModel : MonoBehaviour {

    [SerializeField]
    float dmg  ,range ,hp ,atkSpeed,moveSpeed ;

	[HideInInspector]
	public NavMeshAgent agent;

	[HideInInspector]
	public GameObject myTarget ;

    [HideInInspector]
	public Rigidbody rigid;

	[HideInInspector]
	public Animator anim;

	[Space]
	public GameObject EffectOnHit;


    public float MyDamge 
    {
        get {return dmg;}
        set{dmg = value;}
    }

    public float MyRange
    {
        get { return range;}
        set{ range = value; }
    }

    public float MyHp
    {
        get{return hp;}
        set{hp = value;}
    }

    public float MyAtkSpeed 
    {
        get{return atkSpeed;}
        set{ atkSpeed = value; }
    }

	public float MyMoveSpeed 
	{
		get{return moveSpeed;}
		set{ moveSpeed = value; }
	}

	[SerializeField]
	private float cost;
	public float MyCost 
	{
		get{return cost;}
		set{ cost = value;}
	}




	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

		myTarget = GameObject.Find ("Player");

	}

}

