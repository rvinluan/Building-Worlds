using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider frontleft;
	public WheelCollider frontright;
	public WheelCollider backleft;
	public WheelCollider backright;
	
	public int rpm = 400;
	public int steerValue = 10;
	
	// Use this for initialization
	void Start () {
		//lower the center of mass
		rigidbody.centerOfMass -= new Vector3(0, 3f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//move the wheels
		frontleft.motorTorque = rpm * -Input.GetAxis ("Vertical");
		frontright.motorTorque = rpm * -Input.GetAxis ("Vertical");
		//backleft.motorTorque = rpm * -Input.GetAxis ("Vertical");
		//backright.motorTorque = rpm * -Input.GetAxis ("Vertical");
		
		
		//steering
		frontleft.steerAngle = steerValue * Input.GetAxis("Horizontal");
		frontright.steerAngle = steerValue * Input.GetAxis("Horizontal");
	}
	
	void FixedUpdate() {
		Debug.Log ("hey");
		rigidbody.AddForce(Vector3.down * 3);
	}
}
