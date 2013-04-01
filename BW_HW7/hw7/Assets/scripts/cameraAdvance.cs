using UnityEngine;
using System.Collections;

public class cameraAdvance : MonoBehaviour {
	
	private Vector3 currentPosition;
	private float advanceBy = 100f;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown ("space") ) {
			StartCoroutine(moveRight( advanceBy ));
		}
	}
	
	IEnumerator moveRight(float amount) {
		Vector3 startPosition = currentPosition;
		Vector3 endPosition = currentPosition += new Vector3(amount,0,0);
		float t = 0;
		while( t < 1 ) {
		transform.position = Vector3.Lerp (startPosition, endPosition, t);
		yield return 0;
		t+= 1 * Time.deltaTime * 2;
		}
		currentPosition = endPosition;
	}
}
