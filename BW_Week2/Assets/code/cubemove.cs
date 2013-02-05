using UnityEngine;
using System.Collections;

public class cubemove : MonoBehaviour {
	
	//you can see public variables in Unity's inspector
	//if these are changed in the inspector, they stay that way
	//so in practice these are kind of defaults
	//make sure to check the inspector to see if those values have overriden these
	public float speed = 2f;
	public float distance = 6f;
	public float scaleMax = 8f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine( Movie() );
	}
	
	// Update is called once per frame
	void Update () {
		//move 2 units in one second
		//transform.position += new Vector3 (0f, 2f, 0f) * Time.deltaTime;
		
		//bounce
		//transform.position += new Vector3 (0f, Mathf.Sin( Time.time * speed ), 0f) * Time.deltaTime * distance;
		
		//rotate and scale
		//transform.Rotate( new Vector3 ( 0f, 10f, 0f ) * Time.deltaTime );
		//transform.localScale += new Vector3 (0f, Mathf.Sin( Time.time * speed ), 0f) * Time.deltaTime * scaleMax;
		
		//move forward, no matter what direction forward is.
		//transform.position += transform.forward * Time.deltaTime;
		//see also: transform.right, transform.up
	}
	
	//Coroutines!
	IEnumerator Movie ( /* no params for now */ ) {
		while(true) {
			transform.position += transform.forward;
			yield return new WaitForSeconds(1f);
		}
	}
	
	
}
