using UnityEngine;
using System.Collections;

public class WindCreator : MonoBehaviour {
	
	public WindParticle prefab;
	public int windCount = 1;
	
	// Use this for initialization
	void Start () {
		
		for( int i = 0; i < windCount; i++ ) {
			WindParticle twp = Instantiate ( prefab, new Vector3(
				-60f, Random.Range(0, 48f), Random.Range (15f, 20f)
				), Quaternion.identity ) as WindParticle;
			twp.renderer.enabled = false;
			twp.speed = Random.Range (5f, 30f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void makeWind(int amount, int maxSpeed, int minY, int maxY) {
		for(int i = 0; i < amount; i++) {
			WindParticle twp = Instantiate ( prefab, new Vector3(
				-60f, Random.Range(minY, maxY), Random.Range (15f, 20f)
				), Quaternion.identity ) as WindParticle;
			twp.renderer.enabled = false;
			twp.speed = Random.Range (maxSpeed-10, maxSpeed+10);
			twp.minY = minY;
			twp.maxY = maxY;

		}
	}
}
