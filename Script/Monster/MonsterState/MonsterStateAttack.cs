using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack : StateMonster 
{
    public override void Init()
    {
        base.Init();

        MonsterManager.AttackEventEnter.AddListener(OnEnter);
        MonsterManager.AttackEventExit.AddListener(OnExit);

    }

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);

        if (isActiveAndEnabled)
        {
            StartCoroutine("DelayAttack");
        }
    }

	void Update ()
	{

	}
        


	public IEnumerator   DelayAttack()
    {
		yield return new WaitForSeconds (monsterModel.MyAtkSpeed/2);
		Attack ();
		yield return new WaitForSeconds (monsterModel.MyAtkSpeed);

		OnStateChange ("Attack","Idle");
    }

	public virtual void  Attack ()
	{
		
	}
		

}
