using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour {
	
	public Light glower;
	
	bool growing;
	float growRate;
	Light thisGlow;
	
	// Use this for initialization
	void Start () {
		growRate = Random.value * 0.1f;
		thisGlow = Instantiate ( glower, transform.position, Quaternion.identity ) as Light;
		thisGlow.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(thisGlow.intensity <= 0.1) {
			growing = true;
		}
		if(thisGlow.intensity >= 1) {
			growing = false;
		}
		if(growing) {
			thisGlow.intensity += growRate;
		} else {
			thisGlow.intensity -= growRate;
		}
	}
}
