using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour {
	
	public int speed = 1;
	public int maxSpeed = 5;
	public int slowSpeed = 20;
	public int turnFactor = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//clip velocity
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
		rigidbody.AddForce (transform.right * Input.GetAxis("Vertical") * speed, ForceMode.VelocityChange);
		if(Input.GetKeyUp ("w") || Input.GetKeyUp ("s")) {
			rigidbody.AddForce(-rigidbody.velocity*slowSpeed);
		}
		if(Input.GetKey("a") || Input.GetKey("d")) {
			transform.Rotate(Vector3.up * Input.GetAxis ("Horizontal") * turnFactor);
		}
	}
}
