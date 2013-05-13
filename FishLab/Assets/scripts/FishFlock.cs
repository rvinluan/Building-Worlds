using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishFlock : MonoBehaviour {
	
	Transform[] all;
	
	public int sight = 100;
	public int separation = 1;
	public int alignment = 1;
	public int cohesion = 1;
	
	public int speed = 10;
	
	Vector3 separationForce;
	Vector3 alignmentForce;
	Vector3 cohesionForce;
	
	// Use this for initialization
	void Start () {
		all = GameObject.Find("FishManager").GetComponent<FishManager>().allFish;
	}
	
	// Update is called once per frame
	void Update () {
		List<Transform> nearby = new List<Transform>();
		
		//put all nearby fish into a List
		for(int i = 0; i < all.Length; i++) {
			if( Vector3.Distance(all[i].position, transform.position) <= sight ) {
				nearby.Add(all[i]);
			}
		}
		
		Vector3 sumSeparationVector = Vector3.zero;
		Vector3 sumAlignmentVector = Vector3.zero;
		Vector3 sumCohesionVector = Vector3.zero;
		
		foreach (Transform fish in nearby) {
			sumSeparationVector += (transform.position - fish.position).normalized;
			sumAlignmentVector += fish.forward;
			sumCohesionVector += fish.position;
		}
		
		separationForce = sumSeparationVector / nearby.Count;
		alignmentForce = sumAlignmentVector / nearby.Count;
		cohesionForce = ((sumCohesionVector / nearby.Count) - transform.position).normalized;
		
		transform.rotation = Quaternion.LookRotation( rigidbody.velocity );
		
		if( transform.position.magnitude > 100) {
			rigidbody.AddForce ( -transform.position.normalized * speed * 5f, ForceMode.Force );
		}
	}
	
	void FixedUpdate() {
		rigidbody.AddForce ( separationForce * separation * speed, ForceMode.Acceleration );
		rigidbody.AddForce ( alignmentForce * alignment * speed, ForceMode.Acceleration );
		rigidbody.AddForce ( cohesionForce * cohesion * speed, ForceMode.Acceleration );
	}
}
