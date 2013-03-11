using UnityEngine;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
	
	GameObject pm;
	WindCreator wc;
	
	// Use this for initialization
	void Start () {
		pm = GameObject.Find ("Particle Manager");
		wc = pm.GetComponent<WindCreator>();
		InvokeRepeating("analyzeWaveform", 0f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	float map(float val, float start1, float stop1, float start2, float stop2) {
		if(val < start1) {
	        return start2;
	    } else if (val > stop1) {
	        return stop2;
	    }

	    //figure out how wide each range is
	    float range1 = stop1 - start1;
	    float range2 = stop2 - start2;

	    //find value in between 0 and 1
	    float normalizedValue = (val - start1) / range1;

	    //convert into range2
	    return start2 + (normalizedValue * range2);

	}
	
	void analyzeWaveform() {
		float[] spectrum = audio.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);
		int i = 0;
		float avgHigh = 0;
		float avgMid = 0;
		float avgLow = 0;
		while(i<200) {
			avgLow += spectrum[i];
			avgMid += spectrum[i+500];
			avgHigh += spectrum[i+800];
			i++;
		}
		avgHigh /= 200;
		avgMid /= 200;
		avgLow /= 200;
		wc.makeWind ( (int) map ( -avgLow, 0, 20, 1, 5 ), 20, 10, 20 );
		wc.makeWind ( (int) map ( -avgMid, 0, 30, 1, 8 ), 20, 20, 30 );
		wc.makeWind ( (int) map ( -avgHigh, 0, 30, 1, 8 ), 20, 30, 40 );
		//Debug.Log ("" + Mathf.Log (avgLow) + ";" + Mathf.Log(avgMid) + ";" + Mathf.Log(avgHigh));
	}
}
