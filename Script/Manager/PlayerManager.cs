using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageEvent : UnityEvent <GameObject,float> {}
public class PlayerEvent : UnityEvent <float> {}

public class PlayerManager : MonoBehaviour {

	public static PlayerDamageEvent PlayerDamage = new PlayerDamageEvent ();

	public static UnityEvent PlayerDeath = new UnityEvent ();

	public static PlayerEvent PlayerRecive = new PlayerEvent ();

}
