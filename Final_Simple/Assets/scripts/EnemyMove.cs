using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	public Transform player;
	public float maxSpeed = 20;
	Vector3 target;
	public float movementSpeed = 0.3f;
	
	// Use this for initialization
	void Start () {
		target = player.position;
		animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
		target = player.position;
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
		rigidbody.AddForce ((target - transform.position).normalized * movementSpeed);
		transform.rotation = Quaternion.LookRotation((target - transform.position).normalized);
		transform.rotation *= Quaternion.Euler(0,90,0);
	}
}
