using UnityEngine;
using System.Collections;
//USELESS STUFF
public static class Initiate {

	public static void Fade (string scene, Color col, float damp) {

		GameObject init = new GameObject ();
	
		init.name = "Fader";
		//init.transform.parent = GameObject.Find("Particles").transform;
		init.transform.parent = null;
		init.AddComponent<Fader> ();
		Fader scr = init.GetComponent<Fader> ();

		scr.fadeDamp = damp;
		scr.fadeScene = scene;
		scr.fadeColor = col;
	
		scr.start = true;

		//Debug.Log ("Created gameobject");

	}
}
