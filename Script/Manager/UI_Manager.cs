using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UI_Event : UnityEvent<float> {}

public class UI_CheckEvent : UnityEvent<string>{}

public class UI_DataChangeEvent :UnityEvent<GameModel.GameData>{}

public class ChangeDataEvent : UnityEvent<int>{}

public class SetDataEvent : UnityEvent<string>{}

public class UI_Manager : MonoBehaviour {

	public static UI_Event Hp = new UI_Event ();
	public static UI_Event CountMonster = new UI_Event ();

	public static UI_CheckEvent Bought = new UI_CheckEvent ();

	public static UI_DataChangeEvent DataChangeEvent = new UI_DataChangeEvent (); 

	public static ChangeDataEvent AddGold = new ChangeDataEvent ();
	public static ChangeDataEvent AddDiamond = new ChangeDataEvent ();
	public static ChangeDataEvent AddEnergy = new ChangeDataEvent ();

	public static ChangeDataEvent SubtractGold = new ChangeDataEvent ();
	public static ChangeDataEvent SubtractDiamond = new ChangeDataEvent ();
	public static UnityEvent SubtractEnergy = new UnityEvent ();

	public static SetDataEvent SetUserData = new SetDataEvent ();
	public static UnityEvent GetUserData = new UnityEvent ();

}
