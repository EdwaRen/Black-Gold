using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DonateButton : MonoBehaviour {
	[HideInInspector]
	public GameObject donateButton ;
	public GameObject partyRect ;
	public GameObject partyRectOther;
	public GameObject cash;
	public GameObject cashSprite;
	public GameObject parentThe;
	public Text percent;
	public Text percentOther;
	public string thisParty;
	private bool spawnCash = false;
	private float increasing = 0;
	private bool maximumReached = false;
	public Text moneyLoss;
	//public string

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Time remaining is set to <=0.1 instead of 0 to avoid complications later on where the timeremaining is immediately reset to 8
		if (Statics.timeRemaining <= 0.1) {
			//Resets the election scene so that it is perfect the next time the user enters the election scene
			increasing = 0;
			spawnCash = false;
			partyRect.transform.position = new Vector3 (partyRect.transform.position.x, -3f, partyRect.transform.position.z);
			partyRectOther.transform.position = new Vector3 (partyRectOther.transform.position.x, -3f, partyRectOther.transform.position.z);

			for (int x = 0; x < 100; x++) {
				Destroy (GameObject.Find ("WadCash(Clone)"));
			}

			maximumReached = false;
		}
	}

	void OnMouseDown() {
		//Takes money away for every click on a political party's donation sprite
		if (maximumReached == false && Statics.pleaseNoClick == false) {
			moneyLoss.text = "-$200";
			Statics.money = Statics.money - 200;
			Statics.moneySpent = Statics.moneySpent + 200;
		}
	}

	void OnMouseUp() {
		moneyLoss.text = "";

		if (thisParty == "Dem" && maximumReached == false && Statics.pleaseNoClick == false) {
			//Makes the bars representing chance of victory go up and down, also dictates the amount of percent change per click
			Statics.PercentRep = Statics.PercentRep - (Statics.PercentDem * 1.02f - Statics.PercentDem);
			Statics.PercentDem = Statics.PercentDem * 1.02f;
			partyRect.transform.position = new Vector3 (partyRect.transform.position.x, partyRect.transform.position.y + 0.06f, partyRect.transform.position.z);
			partyRectOther.transform.position = new Vector3 (partyRectOther.transform.position.x, partyRectOther.transform.position.y - 0.06f, partyRectOther.transform.position.z);
			//Creates a cash sprite that progressivly gets higher the more clicks on the donation button
			cash = (GameObject)Instantiate (cashSprite, new Vector3(cashSprite.transform.position.x -5f ,-4f + increasing, -9.1f ), Quaternion.identity);
			percent.text = "" +  Mathf.Round(Statics.PercentDem) + "%";
			percentOther.text = "" +  Mathf.Round(Statics.PercentRep) + "%";
			increasing = increasing + 0.1f;
			if (Statics.PercentDem >= 99.5 || Statics.PercentDem <= 0.5) {
				//prevents overclicking and having over 100% or less than 0%
				maximumReached = true;
			}
		} else if (thisParty == "Rep" && maximumReached == false && Statics.pleaseNoClick == false) {
			//Does the same thing except for when the donation button is the republican one
			Statics.PercentDem = Statics.PercentDem - (Statics.PercentRep * 1.02f - Statics.PercentRep);
			Statics.PercentRep = Statics.PercentRep * 1.02f;
			partyRect.transform.position = new Vector3 (partyRect.transform.position.x, partyRect.transform.position.y + 0.06f, partyRect.transform.position.z);
			partyRectOther.transform.position = new Vector3 (partyRectOther.transform.position.x, partyRectOther.transform.position.y - 0.06f, partyRectOther.transform.position.z);
			cash = (GameObject)Instantiate (cashSprite, new Vector3(cashSprite.transform.position.x + 5f ,-4f + increasing, -9.1f ), Quaternion.identity);
			percent.text = "" +  Mathf.Round(Statics.PercentRep) + "%";
			percentOther.text = "" +  Mathf.Round(Statics.PercentDem) + "%";
			increasing = increasing + 0.1f;
			if (Statics.PercentDem >= 99.5 || Statics.PercentDem <= 0.5) {
				maximumReached = true;
			}
		}
	}
}
