using UnityEngine;
using System.Collections;
//USELESS STUFF
public class LevelFade : MonoBehaviour {
	public GameObject white;
	// Use this for initialization
	void Awake () {
		if (NextYear.scene3 == true) {
			NextYear.sceneReset = false;
			Application.LoadLevel (NextYear.NextLevelString);
			NextYear.scene3 = false;
		}
		//white = GameObject.Find ("WhiteBackground");
	}
	
	// Update is called once per frame
	void Update () {
		
		//Color clear = new Color (0, 0, 0, 1);

	}
}
