using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MonoBehaviour {
	
	// Update is called once per frame
	public void OnStartPressed () {
        GameEvents.START_GAME.Raise();
	}
}
