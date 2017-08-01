using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateMove : StateMonster 
{
	

    public override void Init()
    {
        base.Init();
        MonsterManager.MoveEventEnter.AddListener(OnEnter);
        MonsterManager.MoveEventExit.AddListener(OnExit);
    }

    void Update ()
    {

        Seek();

    }



    void Seek()
    {

		monsterModel.agent.SetDestination (monsterModel.myTarget.transform.position);

//		Vector3 displacement = monsterModel.myTarget.transform.position - transform.position;
//		Vector3 direct = displacement.normalized;
//		Vector3 velocity = direct * monsterModel.MyMoveSpeed * Time.deltaTime;
//		monsterModel.agent.Move(velocity);

//		transform.position = transform.position + velocity;
//		transform.LookAt (monsterModel.myTarget.transform);

		float dis = Vector3.Distance (monsterModel.myTarget.transform.position,transform.position);
		if ( dis < monsterModel.MyRange) 
		{
			OnStateChange ("Move","Attack");
		}
       
    }


}
