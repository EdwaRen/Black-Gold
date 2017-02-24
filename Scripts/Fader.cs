using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	//Useloss code block replaced by 3-4 lines in another script
	public bool start  = false;
	public float fadeDamp = 0.0f;
	public string fadeScene;
	public float alpha = 0.0f;
	public Color fadeColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		//Debug.Log ("Ongui");
		if (!start) {
			return;
		} else {
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			Texture2D myTex;
			myTex = new Texture2D (1, 1);
			myTex.SetPixel (0, 0, fadeColor);
			myTex.Apply ();

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), myTex);
			alpha = Mathf.Lerp (alpha, 1.1f, fadeDamp * Time.deltaTime);
			if (alpha >= 1) {
				Application.LoadLevel (fadeScene);
			}
		}
			
		
	}
}
