using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineLogger : MonoBehaviour {
	
	List<Vector3> pastPositions = new List<Vector3>();
	LineRenderer lineRenderer;
	int maxPositions = 50;

	// Use this for initialization
	void Start () {
		//InvokeRepeating takes an initial delay as its second parameter
		InvokeRepeating( "recordPosition", 0f, 0.1f );
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void recordPosition() {
		if(pastPositions.Count >= maxPositions) {
			pastPositions.RemoveAt(0);	
		}
		pastPositions.Add (transform.position);
		lineRenderer.SetVertexCount( pastPositions.Count ); //not Length or Length() for some reason
		for(int i = 0; i < pastPositions.Count; i++) {
			lineRenderer.SetPosition( i, pastPositions[i] );
		}
	}
}
