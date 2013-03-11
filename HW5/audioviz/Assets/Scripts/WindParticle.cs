using UnityEngine;
using System.Collections;

public class WindParticle : MonoBehaviour {
	
	public float speed = 3f;
	public Vector3 target;
	public Vector3 targetTarget;
	public float minY, maxY;
	
	bool reachedRightSide = false;
	
	// Use this for initialization
	void Start () {
		setNewTarget ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!reachedRightSide) {
			transform.position += (target - transform.position).normalized * Time.deltaTime * speed;
			
			target += (targetTarget - target).normalized * Time.deltaTime * (speed*3);
			
			if((targetTarget - target).magnitude <= 0.2f ) {
				setNewTarget ();
			}
			
			if(transform.position.x > 50) {
				reachedRightSide = true;
				Destroy(gameObject, 3f);
			}
		}
	}
	
	void setNewTarget() {
		targetTarget = new Vector3(
				100f,
				Random.Range(minY, maxY),
				Random.Range (15f, 20f)
			);
	}
}
