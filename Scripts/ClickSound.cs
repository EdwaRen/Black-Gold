using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {
	//Useless code
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			gameObject.GetComponent<AudioSource>().enabled = false;
			gameObject.GetComponent<AudioSource>().enabled = true;

		}
	}

}
