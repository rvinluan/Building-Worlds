using UnityEngine;
using System.Collections;

public class SpotlightLook : MonoBehaviour {
	
	public Transform playerbot;
	float t;
	Vector3 currentFocus;
	
	
	// Use this for initialization
	void Start () {
		currentFocus = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		currentFocus += (playerbot.position - currentFocus).normalized * ((playerbot.position - currentFocus).magnitude * 0.005f);
		transform.LookAt(currentFocus);
	}
}
