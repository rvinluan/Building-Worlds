using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newRotation = (Vector3.forward * -Input.GetAxis ("Vertical") * 10) + (Vector3.right * -Input.GetAxis ("Horizontal") * 10);
		transform.Find("body").transform.localEulerAngles = newRotation;
		//steer animation
		//transform.Find ("front_right_wheel").transform.localEulerAngles = (Vector3.up * Input.GetAxis ("Horizontal")) * 10;
		//transform.Find ("front_left_wheel").transform.localEulerAngles = (Vector3.up * Input.GetAxis ("Horizontal")) * 10;
		//rolling animation
		transform.Find ("front_right_wheel").transform.Rotate(Vector3.forward * rigidbody.velocity.magnitude / 2);
		transform.Find ("back_right_wheel").transform.Rotate(Vector3.forward * rigidbody.velocity.magnitude / 2);
		transform.Find ("front_left_wheel").transform.Rotate(Vector3.forward * rigidbody.velocity.magnitude / 2);
		transform.Find ("back_left_wheel").transform.Rotate(Vector3.forward * rigidbody.velocity.magnitude / 2);
	}
}
