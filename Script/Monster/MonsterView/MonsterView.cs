using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterView : MonoBehaviour {

    private MonsterModel monsterModel;

    void Awake()
    {
        monsterModel = gameObject.GetComponent<MonsterModel>();

    }

	void Start ()
	{
		
	}

    void OnEnable()
    {
		PlayerManager.PlayerDamage.AddListener (TakeDamge);
//		PoolManager.WarmPool (monsterModel.EffectOnHit,1);
    }

    void Update ()
    {

    }

	void TakeDamge (GameObject g, float d)
	{
		if (g == this.gameObject) {
			monsterModel.MyHp -= d;
			StartCoroutine (EffectHit());
			if (monsterModel.MyHp <= 0) {

				monsterModel.anim.SetTrigger ("Die");

			}
		
		}

	}

	void OnDisable ()
	{
		PlayerManager.PlayerDamage.RemoveListener(TakeDamge);
	}


	IEnumerator EffectHit ()
	{

		EffectOnHit clone = PoolManager.SpawnObject (monsterModel.EffectOnHit,transform.position,transform.rotation).GetComponent<EffectOnHit>();
		yield return new WaitForSeconds (0.3f);
		clone.DestroyEffect ();
	}
}
