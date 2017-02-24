using UnityEngine;
using System.Collections;
//USELESS STUFF
public class Test : MonoBehaviour {
	public string scene;
	public bool isButtonVisible = true;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void OnGUI () {
			if (GUI.Button (new Rect (0, Screen.height / 2, 50, 50), "")) {
				//GUI.color = Color.clear;
				Initiate.Fade (scene, Color.black, 3f);
			}
			
	}

	void Update() {
		//Debug.Log ("Test");
	}
}
