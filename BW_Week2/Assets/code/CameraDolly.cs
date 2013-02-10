using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0f, 0f, 3f) * Time.deltaTime;
	}
}
