using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider frontleft;
	public WheelCollider frontright;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		frontleft.motorTorque = 100 * -Input.GetAxis ("Vertical");
		frontright.motorTorque = 100 * -Input.GetAxis ("Vertical");
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
