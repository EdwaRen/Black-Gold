using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MissionControl : MonoBehaviour {

	public GameObject ActionButton;
	public Sprite[] ButtonSprites = new Sprite[8];
	public GameObject EvilMap;
	public GameObject smoke;
	public GameObject destruction;
	public GameObject News;
	public GameObject hideNewsButton;
	public Sprite[] SchemeSprites = new Sprite[5];
	public Sprite HideNewsSprite;
	public GameObject sovietFlag;
	public GameObject sovietFlag2;
	public Text yearlabel;

	public Sprite newFlag;
	public GameObject yearButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Statics.Region == "Election") {
			//Makes sure the nextYear button cannot be clicked during election tab
			yearButton.GetComponent<BoxCollider> ().enabled = false;
		} else {
			yearButton.GetComponent<BoxCollider> ().enabled = true;

		}
	}

	void OnMouseEnter() {
		if (Statics.OilFriendly == true) {
			//Shows one of four actions when mouseover, two about Soviet and two about Iraq. These are greyed out
			Debug.Log ("Enter detected");
			if (Statics.ActionClickCount == 0) {
				Debug.Log ("Changed");

				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [1];
			} else if (Statics.ActionClickCount == 1) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [3];

			} else if (Statics.ActionClickCount == 2) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [5];

			} else if (Statics.ActionClickCount == 3) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [7];

			}

		}
	}

	void OnMouseExit() {
		Debug.Log ("Enter detected3");

		if (Statics.OilFriendly == true) {
			Debug.Log ("Enter detected2");
			//Shows actions that are returned to their original sprites when mouse has left
			if (Statics.ActionClickCount == 0) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [0];

				Debug.Log ("Changed2");

			} else if (Statics.ActionClickCount == 1) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [2];

			} else if (Statics.ActionClickCount == 2) {
				Debug.Log ("Iraq changed");

				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [4];

			} else if (Statics.ActionClickCount == 3 ) {
				ActionButton.GetComponent<SpriteRenderer> ().sprite = ButtonSprites [6];

			}

		}

	}

	void OnMouseUp() {
		
		if (Statics.OilFriendly == true) {
			
			if (Statics.ActionClickCount == 0) {
				//Enables the consequence of the first action even of bombing siberia
				Statics.SiberiaYear = Statics.year;
				Statics.ActionNews = true;
				Statics.year++;
				Statics.SiberiaBombed = true;
				//Creates some aesthetic smoke in Siberia
				Statics.InstantiateSmoke = (GameObject)Instantiate (smoke, smoke.transform.position, Quaternion.identity);
				Statics.ButtonsEnabled = true;
				Statics.actionsEnabled = true;
				//Newspaper appears and announces what you have done
				News.GetComponent<SpriteRenderer> ().sprite = SchemeSprites[0];
				News.GetComponent<SpriteRenderer> ().enabled = true;
				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
				yearlabel.text = "" + Statics.year;
				//ActionButton
				//Moves player to Siberia
				Statics.Region = "Siberia";
				Statics.moveTo = "Siberia";

			} else if (Statics.ActionClickCount == 1) {
				Statics.ActionNews = true;
				//Enables te consequence of the second action which unlocks the siberian oil fields
				Statics.year++;
				Statics.SiberiaBombed = false;
				Statics.SiberiaEnd = true;
				Statics.Region = "Siberia";
				Statics.moveTo = "Siberia";
				Statics.ButtonsEnabled = true;
				Statics.actionsEnabled = true;
				News.GetComponent<SpriteRenderer> ().sprite = SchemeSprites[1];
				News.GetComponent<SpriteRenderer> ().enabled = true;
				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
				//Changes the soviet flag to an oil flag
				sovietFlag.GetComponent<SpriteRenderer> ().sprite = newFlag;
				sovietFlag2.GetComponent<SpriteRenderer> ().sprite = newFlag;
				yearlabel.text =  "" + Statics.year;

			} else if (Statics.ActionClickCount == 2 ) {
				//Enables the consequence of the third action which destabilizes iraq
				Statics.IraqEnd = false;
				Statics.ActionNews = true;
				Statics.year++;
				Statics.ActionNews = true;
				Statics.SiberiaBombed = false;
				Statics.actionsEnabled = true;
				News.GetComponent<SpriteRenderer> ().sprite = SchemeSprites[2];
				News.GetComponent<SpriteRenderer> ().enabled = true;
				Statics.Region = "Iraq";
				Statics.moveTo = "Iraq";
				yearlabel.text = "" + Statics.year;

				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
			} else if (Statics.ActionClickCount == 3) {
				//Enables the consequence of the fourth action which unlocks the iraqi oil fields
				Statics.IraqEnd = true;
				Statics.ActionNews = true;
				Statics.year++;
				yearlabel.text ="" + Statics.year;
				Statics.ButtonsEnabled = true;
				Statics.SiberiaBombed = false;
				Statics.actionsEnabled = true;
				//Shows up the newspaper
				News.GetComponent<SpriteRenderer> ().sprite = SchemeSprites[3];
				News.GetComponent<SpriteRenderer> ().enabled = true;
				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
				//Creates smoke and destruction that is permaneant in iraq
				Statics.InstantiateDestruction = (GameObject)Instantiate (destruction, new Vector3 (destruction.transform.position.x + 142.6f, destruction.transform.position.y, destruction.transform.position.z), Quaternion.identity);
				Statics.Region = "Iraq";
				Statics.moveTo = "Iraq";
				//Updates what year it is
				yearlabel.text = "" + Statics.year;
			}

			Statics.ActionClickCount++;
			//&& Statics.year >= Statics.SiberiaYear+9
		}
	}
}
