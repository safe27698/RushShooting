using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Animation : MonoBehaviour {


	public GUIAnim[] movein; 

	public void Awake ()
	{
		foreach (GUIAnim n in movein) {
		
			n.MoveIn (GUIAnimSystem.eGUIMove.SelfAndChildren);
		}
	
	}


	public void UI_MoveIn (GUIAnim g)
	{
		g.MoveIn (GUIAnimSystem.eGUIMove.SelfAndChildren);
	}

	public void UI_MoveOut (GUIAnim g)
	{
		g.MoveOut (GUIAnimSystem.eGUIMove.SelfAndChildren);
	}
}
