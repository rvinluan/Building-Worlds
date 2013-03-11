using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	
	bool recordingVector;
	Vector3 direction;
	Vector3 initialMousePosition;
	Rigidbody currentBall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
		    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit = new RaycastHit();
		    if (Physics.Raycast(ray, out rayHit, 1000f)) {
		        if(rayHit.collider.tag == "Ball") {
					if(!recordingVector) {
						recordingVector = true;
						initialMousePosition = rayHit.collider.transform.position;
						currentBall = rayHit.rigidbody;
					}
				}
			}
		}
		
		if(Input.GetMouseButtonUp(0)) {
			direction = findFeltMousePoint() - initialMousePosition;
			Debug.Log (direction);
			recordingVector = false;
			if(currentBall != null) {
				currentBall.AddForce ( new Vector3( -direction.x, direction.y, -direction.z ) * 100 );
			}
		}
	}
	
	Vector3 findFeltMousePoint() {
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		if( Physics.Raycast (r, out rayHit, 1000f) ) {
			if(rayHit.collider.tag == "Felt") {
				//Debug.Log(rayHit.point);
				return rayHit.point;
			}
		}
		
		return Vector3.zero;
	}
}
