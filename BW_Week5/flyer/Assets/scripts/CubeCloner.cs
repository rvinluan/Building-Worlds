using UnityEngine;
using System.Collections;

public class CubeCloner : MonoBehaviour {
	
	public Flyer cubePrefab;
	public int cubeCount = 1;
	
	// Use this for initialization
	void Start () {
		for( int i = 0; i < cubeCount; i++) {
			Flyer tempFlyer = Instantiate ( cubePrefab, Vector3.zero, Quaternion.identity ) as Flyer;
			tempFlyer.cubeSpeed = 3f;
			tempFlyer.renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
