using UnityEngine;
using System.Collections;

public class AntiRoll : MonoBehaviour {
	
	public WheelCollider wheelL;
	public WheelCollider wheelR;
	public int antiRoll;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate() {
		WheelHit hit;
		float travelL = 1f;
		float travelR = 1f;
		
		bool groundedL = wheelL.GetGroundHit(out hit);
		if(groundedL) {
			travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
		}
		
		bool groundedR = wheelR.GetGroundHit(out hit);
		if(groundedR) {
			travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
		}
		
		float antiRollForce = (travelL - travelR) * antiRoll;
		
		if(groundedL) {
			transform.parent.rigidbody.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
		}
		
		if(groundedR) {
			transform.parent.rigidbody.AddForceAtPosition(wheelR.transform.up * antiRollForce, wheelR.transform.position);			
		}
	}
}
