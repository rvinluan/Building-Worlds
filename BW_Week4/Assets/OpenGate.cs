using UnityEngine;
using System.Collections;

public class OpenGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void open() {
		StartCoroutine( gateOpen() );
	}
	
	IEnumerator gateOpen() {
		yield return new WaitForSeconds(1.5f);
		while( transform.position.y >= 66f ) {
			transform.position += new Vector3( 0f, -10f, 0f ) * Time.deltaTime;
			yield return 0;
		}
		yield return StartCoroutine( gateClose() );
	}
	
	IEnumerator gateClose() {
		yield return new WaitForSeconds(1f);
		while( transform.position.y <= 78f ) {
			transform.position += new Vector3( 0f, 10f, 0f ) * Time.deltaTime;
			yield return 0;
		}
	}
}
