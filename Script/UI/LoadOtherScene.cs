using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOtherScene : MonoBehaviour {
	

	private UI_Controller ui_Controller;
	public SaveData data;

	public void Awake ()
	{
	}
	public void Start ()
	{
		ui_Controller = gameObject.GetComponent<UI_Controller> ();
	}

	public void LoadLevel (string level)
	{

		Time.timeScale = 1;
		GUIAnimSystem.Instance.LoadLevel (level,0);

	}

	public void StartState ()
	{
		Time.timeScale = 1;
		if (data.energy >= 1) {
			GUIAnimSystem.Instance.LoadLevel (data.map,0);
			UI_Manager.SubtractEnergy.Invoke ();
		}
	}

	public void LowEnergy (GameObject g)
	{
		if (data.energy <= 0) {
		
			StartCoroutine (LowerEnergy(g));
		
		}
	}

	IEnumerator LowerEnergy (GameObject g)
	{
		g.SetActive (true);
		yield return new WaitForSeconds (1);
		g.SetActive (false);
	}

	public void StartGame (string level)
	{
		if(ui_Controller.m_Energy >= 3)

		{
			Time.timeScale = 1;
			ui_Controller.m_Energy -= 3;
			GUIAnimSystem.Instance.LoadLevel (level,0.5f);

		}
	}

}
