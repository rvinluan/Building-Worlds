using UnityEngine;
using System.Collections;

public class Tumbler : MonoBehaviour {

	float tumbleSpeed = 10;
	float tumbleDegrees = 360 * 3;
	public float waitPeriod;
	
	// Use this for initialization
	void Start () {
		waitPeriod = (Random.value * 2f) + 2f;
		StartCoroutine( tumble () );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void startTumbling() {
		StartCoroutine( tumble () );
	}
	
	IEnumerator tumble () {
		yield return new WaitForSeconds( waitPeriod );
		int degrees = 0;
		while( degrees <= tumbleDegrees/tumbleSpeed ) {
			transform.RotateAroundLocal(Vector3.right, Time.deltaTime * tumbleSpeed);
			degrees++;
			yield return 0;
		}
		yield return StartCoroutine( tumble () );
	}
}
