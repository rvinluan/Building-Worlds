using UnityEngine;
using System.Collections;

public class smoothMove : MonoBehaviour {
	
	public Vector3 target;
	public float timeToTarget;
	
	public Transform sphere;
	public Light cubeLight;
	

	// Use this for initialization
	void Start () {
		cubeLight = transform.Find("Point light").GetComponent<Light>();
		
		Invoke("StartMoving", 2f); //SetTimeout
		InvokeRepeating("StartMoving", 2f, 1f); //SetInterval
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Fixedupdate is called once every now and then
	//timed with the physics engine
	void Fixedupdate () {
		if(Input.GetKey(KeyCode.W)) {
			//see also Input.getAxis("Mouse X");
			rigidbody.AddForce( transform.forward , ForceMode.Acceleration);
		}
		//rigidbody.AddTorque();
	}
	
	IEnumerator StartMove ( Transform destination, float duration ) {
		float t = 0f;
		Vector3 start = transform.position;
		
		while ( t < 1f ) {
			t += Time.deltaTime / duration;
			cubeLight.intensity = t * 8f;
			transform.position = Vector3.Lerp( start, destination.position, t );
			//wait a frame
			yield return 0;
		}
	}
	
	
	
	void StartMoving() {
		StartCoroutine( StartMove ( sphere, timeToTarget ) );		
	}
}
