using UnityEngine;
using System.Collections;

public class wreckingball : MonoBehaviour {
	
	public Transform ball;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ball.localPosition = new Vector3(Input.GetAxis ("Attack") * 16, ball.localPosition.y, ball.localPosition.z);
	}
	
	void OnCollisionEnter(Collision info) {
		if(info.collider.gameObject.transform.parent.tag == "Enemy") {
			info.collider.gameObject.transform.parent.GetComponent<EnemyHealth>().health -= 10;
		}
	}
}
