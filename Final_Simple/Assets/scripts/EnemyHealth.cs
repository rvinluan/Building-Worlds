using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int health = 100;
	public bool dead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
			dead = true;
			Destroy (transform.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collisioninfo) {
	}
}
