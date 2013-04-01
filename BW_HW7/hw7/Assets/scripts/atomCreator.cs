using UnityEngine;
using System.Collections;

public class atomCreator : MonoBehaviour {
	public atom atomPrefab;
	public int cubeCount = 5;

	// Use this for initialization
	void Start () {
		for( int i = 0; i < cubeCount; i++) {
			atom tempAtom = Instantiate ( atomPrefab, Vector3.zero, Quaternion.identity ) as atom;
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
