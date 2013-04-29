using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	Vector3 destination;
	public float speed = 20;
	public float stoppingDistance = 0.1f;
	
	// Use this for initialization
	void Start () {
		SetNewDestination();
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion.LookRotation takes a forward vector and converts it into a Quaternion.
		transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
	}
	
	void FixedUpdate() {
		//swim to destination
		rigidbody.AddForce ( (destination - transform.position).normalized * Time.fixedDeltaTime * speed, ForceMode.VelocityChange );
		
		//if we've reached our current destination, set a new one.
		if( Vector3.Distance(transform.position, destination) <= stoppingDistance ) {
			SetNewDestination();
		}
	}
	
	
	//overflowing into each other. This is good practice!
	void SetNewDestination() {
		SetNewDestination(20f);
	}
	
	void SetNewDestination(float range) {
		SetNewDestination( Random.insideUnitSphere * range );		
	}
	
	void SetNewDestination(Vector3 newDestination) {
		destination = newDestination;
	}
}
