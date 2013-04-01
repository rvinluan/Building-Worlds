using UnityEngine;
using System.Collections;

public class atom : MonoBehaviour {

	public float cubeSpeed;
	public Vector3 cubeTarget;
	public Vector3 targetTarget;
	
	float targetRange = 5f;

	// Use this for initialization
	void Start () {
		SetNewTarget();	
	}
	
	// Update is called once per frame
	void Update () {
		//move towards the cubeTarget by speed every 1 second
		transform.position += (cubeTarget - transform.position).normalized * Time.deltaTime * cubeSpeed;
		
		//move the target towards the targetTarget by speed every 1 second
		cubeTarget += (targetTarget - cubeTarget).normalized * Time.deltaTime * (cubeSpeed*2);
		
		//check if the cube's target has reached its own target
		if( (targetTarget - cubeTarget).magnitude < 0.1f ) {
			SetNewTarget ();
		}
	
	}

	void SetNewTarget() {
		//by only setting the targetTarget, and making the cubeTarget move twice as fast as the cube,
		//we keep the number of sharp edges to a minimum.
		//it's because the cube's target isn't jumping around, and the cube hardly ever reaches its target.
		targetTarget = new Vector3 ( Random.Range (-targetRange, targetRange),
								Random.Range(-targetRange, targetRange),
								Random.Range (-targetRange, targetRange));
	}


}
