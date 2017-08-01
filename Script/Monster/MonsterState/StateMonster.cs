using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public abstract class StateMonster : MonoBehaviour {

    protected Animator anim;
    protected MonsterModel monsterModel;
	protected GameObject gm;

    public void Awake()
    {
        Init();
		monsterModel.myTarget = GameObject.FindGameObjectWithTag ("Player");
		monsterModel.agent = GetComponent<NavMeshAgent> ();
    }

    public virtual void Init()
    {
        monsterModel = gameObject.GetComponent<MonsterModel>();
        anim = gameObject.GetComponent<Animator>();
    }

    public virtual void OnEnter(Animator aim)
    {
        if(this.anim == aim)
        {
            enabled = true;
        }
    }

    public virtual void OnExit(Animator aim)
    {
        if (this.anim == aim)
        {
            enabled = false;
        }
    }

    public virtual void OnStateChange(string from ,string to)
    {
        anim.ResetTrigger(from);
        anim.SetTrigger(to);
    }
}
