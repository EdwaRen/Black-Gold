using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TravelTexas : MonoBehaviour {
	
	public Sprite spaced = new Sprite();
	public Sprite spaced2 = new Sprite();
	public GameObject Computer;
	public GameObject Menu;
	public string regionName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		if (Statics.actionsEnabled == true) {
			//Changes the sprite of the mouseovered region to one which is indented visually indenting how it is mousedover
			transform.GetComponent<SpriteRenderer> ().sprite = spaced;
		}
	}

	void OnMouseExit() {
		if (Statics.actionsEnabled == true) {
			//Restores the original sprite of the region when no more mouseover
			transform.GetComponent<SpriteRenderer> ().sprite = spaced2;
		}

	}

	void OnMouseUp() {
		if (Statics.actionsEnabled == true) {
			//Goes to the specified region when clicked
			if (regionName == "Texas") {
				Statics.moveTo = "Texas";
				Statics.Region = "Texas";
				Statics.ButtonsEnabled = true;
			} else if (regionName == "Alberta") {
				Statics.moveTo = "Alberta";
				Statics.Region = "Alberta";
				Statics.ButtonsEnabled = true;
			} else if (regionName == "Siberia") {
				Statics.moveTo = "Siberia";
				Statics.Region = "Siberia";
				Statics.ButtonsEnabled = true;
			} else if (regionName == "Iraq") {
				Statics.moveTo = "Iraq";
				Statics.Region = "Iraq";
				Statics.ButtonsEnabled = true;
			} else if (regionName == "HQ") {
				Statics.moveTo = "HQ";
				Statics.Region = "HQ";
				Statics.ButtonsEnabled = false;
			}
		}
	}
}
