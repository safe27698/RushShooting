using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public SaveData data;

	[Space]
	public Transform[] spawnMonster;
	public GameObject[] monster;
	public int numOfMonster;
	public int rateMonster;
	private int countMon;
	[Space]
	public Transform[] spawnBoss;
	public GameObject[] boss;
	public int numOfBoss;
	public int rateBoss;
	private int countBoss;

	private int totalMon;
	private int totalNumOfMon;

	[Space]
	public GameObject[] potions;
	public Transform[] spawnPotion;

	public void Awake ()
	{

		MonsterManager.SubtractMonsterCheck.AddListener (SubtractTotalMonster);
		numOfMonster = data.numOfMonster;
		numOfBoss = data.numOfBoss;
		totalNumOfMon = data.numOfMonster+data.numOfBoss;
	}


	void Start ()
	{
		
		
		foreach (GameObject g in monster) 
		{
			PoolManager.WarmPool (g,10);
		}
		foreach (GameObject g in boss) 
		{
			PoolManager.WarmPool (g,5);
		}


		InvokeRepeating ("SpawnMonster", 0,rateMonster);
		InvokeRepeating ("SpawnBossMonster", rateBoss,rateBoss);

		foreach (GameObject g in potions) 
		{
			PoolManager.WarmPool (g,5);
		}
	}

	void Update()
	{


	}


	void SpawnMonster ()
	{
		if(totalMon < 10)
		{
			if (countMon < numOfMonster) {
				int randomPosi = Random.Range (0,spawnMonster.Length);
				int randomMon = Random.Range (0,monster.Length);
				MonsterModel m =  PoolManager.SpawnObject (monster[randomMon],spawnMonster[randomPosi].position,spawnMonster[randomPosi].rotation).GetComponent<MonsterModel>();
				m.MyCost = (float)100/(totalNumOfMon) ;
				m.MyDamge += m.MyDamge * (float)(0.2 * data.levelMonster);
				m.MyHp += m.MyHp * (float)(0.2 * data.levelMonster);
				countMon++;
				totalMon++;
			}
		}

	}

	void SpawnBossMonster ()
	{
		if (countBoss < numOfBoss) {
			int randomPosi = Random.Range (0,spawnBoss.Length);
			int randomMon = Random.Range (0,spawnBoss.Length);
			MonsterModel m =  PoolManager.SpawnObject (boss[randomMon],spawnBoss[randomPosi].position,spawnBoss[randomPosi].rotation).GetComponent<MonsterModel>();
			m.MyCost = (float)100/(totalNumOfMon) ;
			m.MyDamge += m.MyDamge * (float)(0.2 * data.levelMonster);
			m.MyHp += m.MyHp * (float)(0.2 * data.levelMonster);
			countBoss++;
			totalMon++;
		}
		if(totalMon < 10)
		{
			
		}

	}

	public void SubtractTotalMonster ()
	{
		totalMon--;
	}

//	public void SpawnPotions ()
//	{
//		int randomPosi = Random.Range (0,spawnPotion.Length);
//		int randomPoti = Random.Range (0,potions.Length);
//		PoolManager.SpawnObject (potions[randomPoti],spawnPotion[randomPosi].position,spawnPotion[randomPosi].rotation);
//	}

}
