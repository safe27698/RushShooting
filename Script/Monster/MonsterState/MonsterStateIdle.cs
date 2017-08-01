using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateIdle : StateMonster {



    public override void Init()
    {
        base.Init();
        MonsterManager.IdleEventEnter.AddListener(OnEnter);
        MonsterManager.IdleEventExit.AddListener(OnExit);

    }

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);
        if(isActiveAndEnabled)
        {
			OnStateChange ("Idle","Move");
        }

	}


    
    void Update ()
    {

    }
		
   
}
