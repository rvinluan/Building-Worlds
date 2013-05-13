using UnityEngine;
using System.Collections;

public class FishManager : MonoBehaviour {
	
	public Transform FishPrefab;
	public Transform[] allFish;
	
	int numFish = 40;

	// Use this for initialization
	void Start () {
		allFish = new Transform[numFish];
		for(int i = 0; i < numFish; i++) {
			Transform f = Instantiate (FishPrefab, Random.insideUnitSphere * 50, Random.rotation) as Transform;
			allFish[i] = f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
