using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckState : MonoBehaviour {
	public SaveData saveData;
	public Button button;
	public GameObject complete;
	public GameObject[] star;
	public int currentState;
	public Text state;

	public GameObject unlockStage;
	public GameObject lockStage;

	public void Start ()
	{
		state.text = ""+(currentState+1);

	}

	public void OnEnable ()
	{
//		if (saveData.completeState[currentState] == true) {
//			button.interactable = false;
//			complete.SetActive (true);
//			if (saveData.timer[currentState] <= 30) {
//				star [0].SetActive (true);
//			} 
//			else if (saveData.timer[currentState] <= 60) {
//				star [0].SetActive (true);
//				star [1].SetActive (true);
//			}
//			else if (saveData.timer[currentState] > 60) {
//				star [0].SetActive (true);
//				star [1].SetActive (true);
//				star [2].SetActive (true);
//			}
//		}

		if(currentState == 0)
		{
			if (saveData.timer[currentState] == 0)
			{
				unlockStage.SetActive (true);
			}
			else if (saveData.timer[currentState] > 0)
			{
				complete.SetActive (true);
				if (saveData.timer[currentState] <= 30) {
					star [0].SetActive (true);
				} 
				else if (saveData.timer[currentState] <= 60) {
					star [0].SetActive (true);
					star [1].SetActive (true);
				}
				else if (saveData.timer[currentState] > 60) {
					star [0].SetActive (true);
					star [1].SetActive (true);
					star [2].SetActive (true);
				}
			}
		}
		else if (saveData.timer[currentState-1] == 0)
		{
			lockStage.SetActive (true);
			button.interactable = false;
		}

		else if (saveData.timer[currentState] == 0)
		{
			unlockStage.SetActive (true);
		}
		else if (saveData.timer[currentState] > 0)
		{
			complete.SetActive (true);
			if (saveData.timer[currentState] <= 30) {
				star [0].SetActive (true);
			} 
			else if (saveData.timer[currentState] <= 60) {
				star [0].SetActive (true);
				star [1].SetActive (true);
			}
			else if (saveData.timer[currentState] > 60) {
				star [0].SetActive (true);
				star [1].SetActive (true);
				star [2].SetActive (true);
			}
		}


	}
}
