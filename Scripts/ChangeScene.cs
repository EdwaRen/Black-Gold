using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	void Start() {
		//Region is set to null at the beginning to avoid the music of the texas region playing too early
		Statics.Region = "";
		Statics.moveTo = "";
	}

	// Update is called once per frame
	public void ChangeToScene (int sceneToChangeTo) {
		//Loads the Texas default game scene
		//int test = sceneToChangeTo;
		//ScreenFader (true);
		//StartCoroutine(DoFade());
		Application.LoadLevel (sceneToChangeTo);
		Statics.Region = "Texas";
		Statics.moveTo = "Texas";
	}
}
