using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public float moveSpeed = 90f;
	public float turnSpeed = 100f;
	public float gravity = 10f;
	
	CapsuleCollider boundingCapsule;
	Vector3 p1;
	Vector3 p2;
	
	// Use this for initialization
	void Start () {
		boundingCapsule = GetComponent<CapsuleCollider>();
		p1 = transform.position + boundingCapsule.center + Vector3.up * -boundingCapsule.height * 0.5f;
		p2 = p1 + Vector3.up * boundingCapsule.height;
	}
	
	// Update is called once per frame
	void Update () {
		boundingCapsule = GetComponent<CapsuleCollider>();
		p1 = transform.position + boundingCapsule.center + Vector3.up * -boundingCapsule.height * 0.5f;
		p2 = p1 + Vector3.up * boundingCapsule.height;
		RaycastHit testhit;
		if(capsulecast(out testhit, transform.forward*moveSpeed*Time.deltaTime)) {
				//Debug.DrawRay(testhit.point, testhit.normal);
				Debug.DrawLine(transform.position, testhit.point, Color.yellow);
		}
		
		#region MOVING
		if(Input.GetKey (KeyCode.W)) {
			RaycastHit hit;
			if(!capsulecast(out hit, transform.forward * moveSpeed * Time.deltaTime)) {
				transform.position += transform.forward * moveSpeed * Time.deltaTime;
			} else {
				//check if slope
				if(	hit.transform.gameObject.tag == "slope" ) {
					transform.position += transform.forward * moveSpeed * Time.deltaTime * 0.5f;
					transform.position += Vector3.up * gravity * Time.deltaTime * 2f;
					RaycastHit slopeHit;
					if( Physics.Raycast( transform.position, Vector3.down, out slopeHit, boundingCapsule.height ) ) {
						Debug.DrawLine (transform.position, transform.position + Vector3.down*slopeHit.distance, Color.white);
						transform.position += Vector3.down*slopeHit.distance;
						//transform.position += Vector3.up*0.4f;
					}
				}
			}
		}
		#endregion
		
		#region TURNING
		if(Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}
		#endregion
		
		#region GRAVITY
		RaycastHit floorhit;
		//Debug.DrawRay(transform.position, Vector3.down * boundingCapsule.height * 0.5f, Color.magenta);
		if( !Physics.Raycast( transform.position, Vector3.down, out floorhit, boundingCapsule.height/2f ) ) {
			transform.position += Vector3.down * gravity * Time.deltaTime;
		}
		#endregion
	}
	
	bool capsulecast(out RaycastHit hit, Vector3 direction) {
		//Debug.DrawRay(p1, direction*1f, Color.magenta);
		//Debug.DrawRay(p2, direction*1f, Color.magenta);
		RaycastHit tophit;
		RaycastHit bottomhit;
		bool result1 = Physics.SphereCast (p1, boundingCapsule.radius, direction, out bottomhit, boundingCapsule.radius);
		bool result2 = Physics.SphereCast (p2, boundingCapsule.radius, direction, out tophit, boundingCapsule.radius);
		if(result1) {
			hit = bottomhit;
			return true;
		}
		if(result2) {
			hit = tophit;
			return true;
		}
		hit = tophit; //if hit isn't assigned to *something* it throws an error
		return false;
	}
}
