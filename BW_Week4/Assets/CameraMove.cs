using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public int bottomPoint = 30;
	public int topPoint = 88;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (panDown(bottomPoint));
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator panDown(float endY) {
		while( transform.position.y >= endY ) {
			transform.position += new Vector3(0f, -6f, 0f) * Time.deltaTime;
			yield return 0;
		}
		yield return StartCoroutine( panUp(topPoint) );
	}
	
	IEnumerator panUp(float endY) {
		while( transform.position.y <= endY) {
			transform.position += new Vector3(0f, 25f, 0f) * Time.deltaTime;
			yield return 0;
		}
		yield return StartCoroutine( panDown(bottomPoint) );
	}
	
}
