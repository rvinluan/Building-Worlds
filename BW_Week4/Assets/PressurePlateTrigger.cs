using UnityEngine;
using System.Collections;

public class PressurePlateTrigger : MonoBehaviour {
	
	bool wentDown;
	GameObject gate;
	
	// Use this for initialization
	void Start () {
		wentDown = false;
		gate = GameObject.Find("gate");
		print ("startup");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(!wentDown) {
			StartCoroutine(moveDown(transform.parent.gameObject.transform, 1f, 2f));
			StartCoroutine(waitAndDestroy(other.gameObject, 2f));
			gate.GetComponent<OpenGate>().open();
			wentDown = true;
		}
	}
	
	/* code from Eric5h5 on Unity Answers */
	IEnumerator moveDown( Transform transf, float distance, float speed) {
		float startPos = transf.position.y;
		float endPos = startPos - distance;
		float rate = 1f / Mathf.Abs(startPos - endPos) * speed;
		float t = 0f;
		while( t < 1f ) {
			print ("sup");
			t += Time.deltaTime * rate;
			float delta = Mathf.Lerp(startPos, endPos, t);
			transf.position = new Vector3(transf.position.x, delta, transf.position.z);
			yield return 0;
		}
	}
	
	IEnumerator waitAndDestroy( GameObject other, float wait ) {
		yield return new WaitForSeconds(wait);
		Destroy (other);
		wentDown = false;
	}
}
