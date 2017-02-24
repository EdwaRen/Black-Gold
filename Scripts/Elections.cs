using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Elections : MonoBehaviour {
	public GameObject cancelCanvas;
	public GameObject goodCanvas;
	public Text Times ;
	public Text PercentRep;
	public Text PercentDem;
	public Text loss;

	public GameObject TextBackground;
	public Text FinishingText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Statics.Region == "Election") {
			//Automatically sets OIlFriendly to false upon reaching the election tab
			Statics.OilFriendly = false;
			//Disables the default canvas thus hiding the gui text which is a pain in the asjdkabdshjgasdhad
			cancelCanvas.GetComponent<Canvas> ().enabled = false;
			goodCanvas.GetComponent<Canvas> ().enabled = true;
			Debug.Log ("Removing canvas Stuff");
		}
		if (Statics.Region == "Election") {
			if (Statics.timeRemaining > 0) {

				//Displays the time remainng (rounded)
				Statics.timeRemaining -= Time.deltaTime;
				Times.text = "" + Mathf.Round(Statics.timeRemaining);
				Debug.Log (Statics.timeRemaining);
				if (Statics.timeRemaining <= 0) {
					
					//Resets the scene elements when timeRemaining reaches 0
					Statics.pleaseNoClick = true;
					PercentDem.text = "";
					PercentRep.text = "";
					Times.text = "";
					Statics.govNews = Statics.year + 2;

					//restores the old canvas and the default text that comes with it
					cancelCanvas.GetComponent<Canvas> ().enabled = true;
					goodCanvas.GetComponent<Canvas> ().enabled = false;

					//Uses rng to determine if the government has been successfully oiled
					float bribed = Random.value;
					if (Mathf.Round (Statics.PercentDem) >= bribed * 100) {
						Statics.OilFriendly = true;
					} 
					if (Mathf.Round (Statics.PercentRep) >= bribed * 100) {
						Statics.OilFriendly = true;
					} 

					//If not enough money has been donated, then the gov has not been oiled
					if (Statics.moneySpent <= 1700) {
						Statics.OilFriendly = false;
					}


					Debug.Log ("Moving to HQ");
					//Displays the report of the election results
					Statics.actionsEnabled = false;
					TextBackground.GetComponent<SpriteRenderer> ().enabled = true;
					if (Statics.OilFriendly == true) {
						//Text summarizing the election
						FinishingText.text = ("ELECTION RESULTS: \r\n Governemnt has been successfully oiled \r\n You now have access to the special operations room \r\n -------------\r\nYou have contributed a total of \r\n" + Statics.moneySpent); 
					
					} else if (Statics.OilFriendly == false) {
						FinishingText.text = ("ELECTION RESULTS: \r\n Governemnt has not been successfully oiled \r\n This foolish government has restricted our access to the special operations room and we can no longer use it to diversify our oil production. \r\n ---------\r\nYour total contributions this election amounts to: \r\n" + Statics.moneySpent); 
					}
					//Resetting some stuff
					Statics.thisACtionEnabled6 = false;
					Statics.PercentDem = 50;
					Statics.PercentRep = 50;
					Statics.pleaseNoClick = false;
					Statics.moneySpent = 0;

					//Going to HQ immediately afterwards
					Statics.Region = "HQ";
					Statics.moveTo = "HQ";
				}
			} 
		}

		if (Input.GetMouseButtonDown (0) && Statics.thisACtionEnabled6 == false && Statics.thisACtionEnabled6 == false) {
			//Makes the textbackground and the text disappear when the user clicks anywhere
			TextBackground.GetComponent<SpriteRenderer> ().enabled = false;
			FinishingText.text = "";
			Statics.actionsEnabled = true;
			Statics.thisACtionEnabled6 = true;
		}

	}
}
