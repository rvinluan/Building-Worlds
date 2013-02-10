using UnityEngine;
using System.Collections;

public class cubeAppear : MonoBehaviour {
	
	Color originalColor;
	Vector3 originalLocation;
	Vector3 randomLocation;
	float duration;
	float timeStart;
	//this will change depending on the object
	public float offset = 0;
	
	float MapInterval(float val, float srcMin, float srcMax, float dstMin, float dstMax) {
	    if (val>=srcMax) return dstMax;
	    if (val<=srcMin) return dstMin;
	    return dstMin + (val-srcMin) / (srcMax-srcMin) * (dstMax-dstMin);
	}   
	
	float randomBetween(float min, float max) {
		return min + ( Random.value * (max - min) );
	}
	
	// Use this for initialization
	void Start () {
		timeStart = Time.time;
		originalLocation = transform.position;
		originalColor = renderer.material.color;
		renderer.material.color = Color.clear;
		duration = 1f * (offset + 1f);
		
		//go to a random position.
		int positionMax = 80;
		randomLocation = new Vector3( randomBetween(-positionMax, positionMax), 
			randomBetween(-positionMax, positionMax), 
			randomBetween (-positionMax, positionMax) );
		transform.position = randomLocation;

	}
	
	// Update is called once per frame
	void Update () {
		float lerpTime = MapInterval(Time.time, timeStart + duration - 1f, timeStart + duration, 0, 1);
		renderer.material.color = Color.Lerp( Color.clear, originalColor, lerpTime );
		transform.position = Vector3.Lerp( randomLocation, originalLocation, lerpTime ); 
	}
}
