using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
 public class UnityColliderEvent : UnityEvent<Collider>{}
public class CollideTrigger : MonoBehaviour {

	[SerializeField] UnityColliderEvent EnterTriggerEvents;

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		Debug.Log("OnTriggerEnter");
		EnterTriggerEvents.Invoke(col);
	}
	
}
