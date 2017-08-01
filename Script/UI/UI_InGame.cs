using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour {


	public Image hp;
	public Image count;
	public Image rune;
	[Space]
	public SaveData saveData;
	[Space]
	public GameObject gameOver;
	[Space]
	public float timer ;
	public Text text_Timer ;
	[Space]
	public GameObject result;
	public GameObject[] star ;
	[Space]

	public Text text_GoldResult;
	[Space]
	public GameManager gameManager;

	public GameObject teach;

	public void Awake ()
	{

		UI_Manager.Hp.AddListener (ChangeHP);
		MonsterManager.MonsterCount.AddListener (CountMonster);

		PlayerManager.PlayerDeath.AddListener (GameOver);
	}

	public void Start ()
	{
		Player_Rune myRune = saveData.runePlayer.GetComponent<Player_Rune> ();
		rune.sprite = myRune.runeImage;
		Teach (1);
	}

	public void Teach (int i)
	{
		if (i == 1) {
			teach.SetActive (true);
			Time.timeScale = 0;
		}
		else if(i == 0)
		{
			teach.SetActive (false);
			Time.timeScale = 1;
		}



	}
	void Update ()
	{
		CountdownTimer ();

	}

	void ChangeHP (float h)
	{

		hp.fillAmount = h / 100;
	
	}

	void CountMonster (float m)
	{
		count.fillAmount += m / 100;
		Debug.Log (100*count.fillAmount);
		if (count.fillAmount >= 0.99) {
		
			Result ();
		}

	}
		
	void CountdownTimer ()
	{
		timer -= Time.deltaTime;
		text_Timer.text = "" + (int)timer;
		if ((int)timer <= 0) {
			GameOver ();
		}
	}

	void Result ()
	{
//		UI_Manager.AddGold.Invoke ((int)(timer*gameManager.totalMonster));
		Time.timeScale = 0;
		result.SetActive (true);
		if (timer < 60) {
			star [2].SetActive (false);
		} 
		else if (timer < 30) {
			star [1].SetActive (false);
			star [2].SetActive (false);
		}
		text_GoldResult.text = ""+(int)((timer*(gameManager.numOfMonster+gameManager.numOfBoss))/10);
		saveData.goldReceived = (int)((timer*(gameManager.numOfMonster+gameManager.numOfBoss))/10);

//		saveData.timer.Insert(saveData.state,(int)timer);
//		saveData.completeState.Insert (saveData.state,true);


		saveData.timer [saveData.state] = (int)timer;
		saveData.completeState [saveData.state] = true;

//		saveData.time.Add (saveData.state,(int)timer);
//		saveData.complete.Add (saveData.state,true);
	}

	void GameOver ()
	{
		StartCoroutine (GV());
	}

	IEnumerator GV ()
	{
		yield return new WaitForSeconds (1);
		Time.timeScale = 0;
		gameOver.SetActive (true);
	}
		

	public void BuyAlive (GameObject g)
	{
		if(saveData.diamond > 10)
		{
			saveData.diamond -= 10;
			saveData.diamondUsed += 10;
			PlayerManager.PlayerRecive.Invoke (100);
			timer += 60;
			g.SetActive (false);
			Time.timeScale = 1;
		}

	}

	public void PauseGame (GameObject g)
	{
		Time.timeScale = 0;
		g.SetActive (true);
	}

	public void Resume (GameObject g)
	{
		Time.timeScale = 1;
		g.SetActive (false);
	}

}
