using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider frontleft;
	public WheelCollider frontright;
	public WheelCollider backleft;
	public WheelCollider backright;
	
	// Use this for initialization
	void Start () {
		rigidbody.centerOfMass -= new Vector3(0, -1.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//move the wheels
		frontleft.motorTorque = 400 * -Input.GetAxis ("Vertical");
		frontright.motorTorque = 400 * -Input.GetAxis ("Vertical");
		//backleft.motorTorque = 100 * -Input.GetAxis ("Vertical");
		//backright.motorTorque = 100 * -Input.GetAxis ("Vertical");
		
		
		//steering
		frontleft.steerAngle = 10 * Input.GetAxis("Horizontal");
		frontright.steerAngle = 10 * Input.GetAxis("Horizontal");
		
		//adjust slipping
		/*
		float slip = (0.01f + 0.022f/(rigidbody.velocity.magnitude+1))*25000;
		
		frontleft.sidewaysFriction.stiffness = slip;
		frontright.sidewaysFriction.stiffness = slip;
		*/
	}
}
