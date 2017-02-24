using UnityEngine;
using System.Collections;

public class TheRoom : MonoBehaviour {
	public Sprite original = new Sprite();
	public Sprite hoverRoom = new Sprite();
	public GameObject MissionControl;
	public GameObject NextAction;
	public Sprite[] ActionsSprites = new Sprite[5];
	public int MissionCount = 0;
	public GameObject disableText;
	public GameObject closeButton;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if (Statics.Region != "HQ") {
			//When player leaves HQ, makes sprites and their respective boxcolliders invisble and unable to be interacted with
			MissionControl.GetComponent<SpriteRenderer> ().enabled = false;
			NextAction.GetComponent<SpriteRenderer> ().enabled = false;
			disableText.GetComponent<SpriteRenderer> ().enabled = false;
			closeButton.GetComponent<SpriteRenderer> ().enabled = false;
			NextAction.GetComponent<BoxCollider2D> ().enabled = false;
			closeButton.GetComponent<BoxCollider2D> ().enabled = false;

		}
	}

	void OnMouseEnter() {
		if (Statics.OilFriendly == true) {
			//Changes sprites to a more ominous look upon mouse hover
			gameObject.GetComponent<SpriteRenderer> ().sprite = hoverRoom;
		}
	}
	void OnMouseExit() {

		if (Statics.OilFriendly == true) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = original;
		}
	}

	void OnMouseUp() {
		if (Statics.OilFriendly == true ) {
			//enables and makes visible everything in mission control including the map and respective text
			disableText.GetComponent<SpriteRenderer> ().enabled = true;
			closeButton.GetComponent<SpriteRenderer> ().enabled = true;
			closeButton.GetComponent<BoxCollider2D> ().enabled = true;
			//A semi opaque black sprite is cast over everything except the items in MissionControl
			disableText.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.4f);
			MissionControl.GetComponent<SpriteRenderer> ().enabled = true;
			NextAction.GetComponent<BoxCollider2D> ().enabled = true;

			NextAction.GetComponent<SpriteRenderer> ().enabled = true;
			if (Statics.ActionClickCount < 5) {
				//The action button can be only clicked 4 times so after that, an action button with only a manilla folder is displayed
				NextAction.GetComponent<SpriteRenderer> ().sprite = ActionsSprites [Statics.ActionClickCount];
			}
			MissionCount++;
			Statics.actionsEnabled = false;
		}
	}
}
