using UnityEngine;
using System.Collections;

public class GenerateCubes : MonoBehaviour {
	
	float zval;
	float offset;
	
	// Use this for initialization
	void Start () {
		zval = 11;
		offset = 0;
		for(int i = 0; i < 100; i++) {
			GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube ); 	
			cube.transform.position = new Vector3( 0f, 0f, zval );
			cube.transform.localScale *= 3;
			Material newMat = Resources.Load("brick", typeof(Material)) as Material;
			cube.renderer.material = newMat;
			cube.AddComponent("cubeAppear");
			cubeAppear sc = cube.GetComponent<cubeAppear>();
			sc.offset = offset;
			
			zval += 3;
			offset++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
