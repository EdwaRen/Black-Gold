using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NextYear : MonoBehaviour
{
	[HideInInspector]
	//public string scene;
	public static string NextLevelString = "Game1";
	public static bool scene3 = false;
	public Sprite ButtonC = new Sprite ();
	public Sprite ButtonN = new Sprite ();
	public Text yearLabel;
	public Text moneyLabel;
	public Text demandLabel;
	public Text supplyLabel;
	public Text oilLabel;
	public bool startfade = true;

	public GameObject wellBigEmpty;
	public GameObject wellSmallEmpty;

	public static float alpha = 1f;
	public static bool sceneReset = false;
	public GameObject white;
	public GameObject CameraReset;
	private int twoInARow = 0;
	public GameObject[] newOil = new GameObject[1000];
	public Sprite[] NSet = new Sprite[4];
	public Sprite[] NPos = new Sprite[8];
	private int NPosCount = 0 ;
	private int NNegCount = 0;
	public Sprite[] NNeg = new Sprite[7];
	public Sprite[] NAction = new Sprite[4];
	public GameObject News;
	public GameObject hideNewsButton;
	public Sprite OpenNewsButton;
	public Sprite HideNewsSprite;

	public GameObject obj1;
	public GameObject obj2;
	public Text obj4;

	public GameObject DisableText;
	public GameObject Ending;
	public Sprite[] DifferentEnd = new Sprite[3];
	public GameObject Restart;
	public Text YearsSurvived;
	public AudioClip[] endSounds = new AudioClip[4];

	public GameObject yearButton;

	private float supplyDemandCount = 0;

	public GameObject Newspaper;


	// Use this for initialization
	void Start ()
	{
		//startfade = false;
	}
	
	// Update is called once per frame


	void OnMouseEnter ()
	{
		//Changes sprite to give hover effect
		if (Statics.actionsEnabled == true) {
			transform.GetComponent<SpriteRenderer> ().sprite = ButtonC;
		}
	}

	void OnMouseExit ()
	{
		//Changes the sprite back to original
		if (Statics.actionsEnabled == true) {
			transform.GetComponent<SpriteRenderer> ().sprite = ButtonN;
		}
	}

	void OnMouseUp ()
	{
		Debug.Log (NNegCount);
		Debug.Log (NPosCount);

		//Shows some news articles to increase the oil price in the begeiining of the game
		if (Statics.year == 1952 && Statics.actionsEnabled == true) {
			News.GetComponent<SpriteRenderer> ().sprite = NSet [0];
			News.GetComponent<SpriteRenderer> ().enabled = true;
			hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
			Statics.oilPrice = Statics.oilPrice + 2; 
				 
		} else if (Statics.year == 1954 && Statics.actionsEnabled == true) {
			News.GetComponent<SpriteRenderer> ().sprite = NSet [1];
			News.GetComponent<SpriteRenderer> ().enabled = true;
			hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
			Statics.oilPrice = Statics.oilPrice + 3; 

		} else if (Statics.year == 1956 && Statics.actionsEnabled == true) {
			News.GetComponent<SpriteRenderer> ().sprite = NSet [2];
			News.GetComponent<SpriteRenderer> ().enabled = true;
			hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
			Statics.oilPrice = Statics.oilPrice + 4; 

		} else if (Statics.year == 1958 && Statics.actionsEnabled == true) {
			News.GetComponent<SpriteRenderer> ().sprite = NSet [3];
			News.GetComponent<SpriteRenderer> ().enabled = true;
			hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
			Statics.oilPrice = Statics.oilPrice + 4; 

		} else if(Statics.year == Statics.govNews) {
			//The govNews year is when the government is bribed and special news is brought that highlights the extent of bribery
			//Ends the game if too many "positive" things happen
			if (NPosCount > 6) {
				GameObject.Find ("AirSire").GetComponent<AudioSource> ().enabled = true;
				//Loads up the ending sprites
				YearsSurvived.text = "IN BUSINESS FOR " + (Statics.year - 1950) + " YEARS";
				Ending.GetComponent<SpriteRenderer> ().enabled = true;
				Ending.GetComponent<SpriteRenderer> ().sprite = DifferentEnd[2];
				Restart.GetComponent<SpriteRenderer> ().enabled = true;
				Restart.GetComponent<BoxCollider2D> ().enabled = true;
				Statics.actionsEnabled = false;
				Statics.ButtonsEnabled = true;
				Debug.Log ("Game Ended Positive");


					//Makes the newspaper invisible
					Newspaper.GetComponent<SpriteRenderer> ().enabled = false;


			} else if (NNegCount > 6 ) {
				//Ends the game if too many "negative" things happen
				//Loads up the ending sprites

				GameObject.Find ("America").GetComponent<AudioSource> ().enabled = true;
				Ending.GetComponent<AudioSource> ().clip = endSounds[2];
				YearsSurvived.text = "IN BUSINESS FOR " + (Statics.year - 1950)+ " YEARS";
				Ending.GetComponent<SpriteRenderer> ().enabled = true;
				Ending.GetComponent<SpriteRenderer> ().sprite = DifferentEnd[1];
				Restart.GetComponent<SpriteRenderer> ().enabled = true;
				Restart.GetComponent<BoxCollider2D> ().enabled = true;
				//Makes sure user can't press any unnecessary buttons
				Statics.actionsEnabled = false;
				Statics.ButtonsEnabled = true;
				Debug.Log ("Game Ended Negative");

				Newspaper.GetComponent<SpriteRenderer> ().enabled = false;


			} else {

				if (Statics.OilFriendly == true) {
					//If the amount of govNews has not reached its left, this if statement sets the next time govNews will appear and does the action speciifed in the news article 
					Statics.govNews = Statics.govNews + 10;
					//Setting some sprites of the newspaper and the hide news button
					News.GetComponent<SpriteRenderer> ().sprite = NPos [NPosCount];
					News.GetComponent<SpriteRenderer> ().enabled = true;
					hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;
					//Performs the action of each news clipping
					if (NPosCount == 0) {
						Statics.oilPrice = Statics.oilPrice + 4; 
					} else if (NPosCount == 1f) {
						Statics.oilPrice = Statics.oilPrice + 2; 
					} else if (NPosCount == 2f) {
						Statics.money = Statics.money * 1.5f;
					} else if (NPosCount == 3f) {
						Statics.oilPrice = Statics.oilPrice + 3; 

					} else if (NPosCount == 4f) {
						Statics.oilPrice = Statics.oilPrice + 3; 

					} else if (NPosCount == 5f) {
						Statics.oilPrice = Statics.oilPrice + 6; 

					} else if (NPosCount == 6f) {
						Statics.oilPrice = Statics.oilPrice + 4; 

					} 

					NPosCount++;
				} else if (Statics.OilFriendly == false) {
					//Does the same stuff as the previous if statement except this time the government hates you
					Statics.govNews = Statics.govNews + 10;
					News.GetComponent<SpriteRenderer> ().sprite = NNeg [NNegCount];
					News.GetComponent<SpriteRenderer> ().enabled = true;
					hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsSprite;

					if (NNegCount == 0) {
						Statics.oilPrice = Statics.oilPrice -3; 
					} else if (NNegCount == 1) {
						Statics.oilPrice = Statics.oilPrice -2; 
					} else if (NNegCount == 2) {
						Statics.oilPrice = Statics.oilPrice - 3;
					} else if (NNegCount == 3) {
						Statics.oilPrice = Statics.oilPrice -2; 

					} else if (NNegCount == 4) {
						Statics.oilPrice = Statics.oilPrice -3; 

					} else if (NNegCount == 5) {
						Statics.oilPrice = Statics.oilPrice -6; 

					} else if (NNegCount == 6) {
						Statics.oilPrice = Statics.oilPrice -10; 

					}  else if (NNegCount == 7) {
						Statics.oilPrice = Statics.oilPrice -8; 

					} 
					NNegCount++;
				}
			}

		} else {
			//If the year does not necessite news, then this hides the newspaper
			News.GetComponent<SpriteRenderer> ().enabled = false;
			hideNewsButton.GetComponent<SpriteRenderer> ().sprite = OpenNewsButton;
		}

		Statics.OilSupply = Statics.totalWells * 3;
		if (Statics.actionsEnabled == true) {
			
			//Actions enabled indicates that the button was able to be clicked
			//Money decreases slightly each turn for every well owned
			Statics.money = Statics.money - 2 * Statics.totalWells;
			Statics.year++;

			//Resets some specifying action
			Statics.thisActionEnabled = true;
			yearLabel.text = Statics.year.ToString ();
		
			//Creates a brief fade for the scene to visuallly indicate the next yeaer
			startfade = true;
			//CameraReset.transform.position = Statics.CameraOriginalPos;


			Destroy (GameObject.Find ("Spinner(Clone)"));
			//Makes the plane disappear
			if (Statics.planeStatic != null) {
				Statics.planeStatic.GetComponent<SpriteRenderer> ().enabled = false;
			}
			Statics.movePlane = false;

			for (int i = 0; i < 28; i++) {
				//This basically detect if an oil rig is placed on a oil deposit
				if (Statics.oilTrueTexas [i] == true) {
					//The following line is the amount of undiscovered oil reserves
					Statics.OilQuantity [i] = Statics.OilQuantity [i] - Statics.OilNumWells [i];
					//The following line updates your money
					Statics.money = Statics.money + Statics.OilNumWells [i] * Statics.oilPrice * 2 + 250;

					if (Statics.OilQuantity [i] <= 0) {
						//Displays a new sprite so that the oil rig is no longer pumping oil
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().sprite = Statics.allOilCopy [Statics.spriteNumTexas [i] + 4];
						//Clean up costs mean that you pay $300 every turn now
						Statics.money = Statics.money - Statics.OilNumWells [i] * Statics.oilPrice * 2 - 400;
						Debug.Log ("Oil less than 0");

					} else if (Statics.OilQuantity [i] <= Statics.randomNumber2 [i] * 10 + 10) {
						//When the amount of oil in a deposit decreases, a new sprite is shown with that decrease in mind
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().sprite = Statics.allOilCopy [Statics.spriteNumTexas [i] + 3];

					} else if (Statics.OilQuantity [i] <= Statics.randomNumber2 [i] * 20 + 20) {
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().sprite = Statics.allOilCopy [Statics.spriteNumTexas [i] + 2];

					} else if (Statics.OilQuantity [i] <= Statics.randomNumber2 [i] * 30 + 30) {
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().sprite = Statics.allOilCopy [Statics.spriteNumTexas [i] + 1];
						//Debug.Log ("SpriteChanged to " + (Statics.spriteNumTexas [i] + 1));
					}

					//Statics.OilQuantity [i] = Statics.OilQuantity [i] - Statics.OilNumWells [i];
				}

				//the following is the total amount of oil supplied through production
				Statics.OilSupply = Statics.OilSupply + 7 * Statics.OilNumWells [i];
				//Statics.OilDemand = Statics.oilPrice * 1.1f;
			}
			if (Statics.OilDemand >= Statics.OilSupply) {
				//Oil demand increases less if it is greater than the amount of oil supplied
				Statics.OilDemand = Statics.OilDemand * 1.01f + 5;
				//Oil price rises when supply can't meet demand
				Statics.oilPrice = Statics.oilPrice + 1f;
				//Debug.Log ("Oil price increased");
				//Debug.Log ("OilDemand " + Statics.OilDemand);
				//Debug.Log ("OilSupply " + Statics.OilSupply);


			} else {
				
				Statics.OilDemand = Statics.OilDemand * 1.02f + 5;
				twoInARow++;
				if (twoInARow >= 2) {
					//Oil price decrease after two turns of oversupply
					Statics.oilPrice--;
					//Debug.Log ("Oil price reduced");
					twoInARow = 0;
				}
			}


			float yearCheck;
			yearCheck = Statics.year / 10;
			if (Statics.year % 10 == 0) {
				//Calls an election year if the year is divisible by 10;
				Statics.moveTo = "Election";
				Statics.Region = "Election";
			}


		}
		Statics.OilSupply = Statics.OilSupply - (7*Statics.emptyWells);


		if (Statics.money < -4000) {
			//Ends the game if you have less than $4000 in the bank
			GameObject.Find ("RiotSound").GetComponent<AudioSource> ().enabled = true;
			//Displays necessary sprites and texts
			YearsSurvived.text = "IN BUSINESS FOR " + (Statics.year - 1950) + " YEARS";
			Ending.GetComponent<SpriteRenderer> ().enabled = true;
			Ending.GetComponent<SpriteRenderer> ().sprite = DifferentEnd[0];
			Restart.GetComponent<SpriteRenderer> ().enabled = true;
			Restart.GetComponent<BoxCollider2D> ().enabled = true;
			//Ensures unnecessary buttons can not be clicked
			Statics.actionsEnabled = false;
			Statics.ButtonsEnabled = false;

			Newspaper.GetComponent<SpriteRenderer> ().enabled = false;


		} 

		if ((Statics.OilDemand / Statics.OilSupply) >= 3) {
			//supplyDemand Count tracks when you are to be fired when supply is much lower than demand
			supplyDemandCount++;

			if (supplyDemandCount == 6) {
				//Warning that the user is about to get fired
				obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.4f);
				Statics.actionsEnabled = false;
				obj4.text = ("The company shareholders are unhappy with the way it's petroleum assets are being managed, increase oil production or you will be fired");
				obj2.GetComponent<SpriteRenderer> ().enabled = true;
				Statics.thisActionEnabled5 = false;

			} else if (supplyDemandCount == 8) {
				//Ends the game with being fired
				if (Statics.year >= 2000) {
					//ends with nuclear war as the world is already addicted and too dependant on oil
					YearsSurvived.text = "IN BUSINESS FOR " + (Statics.year - 1950) + " Years";
					Ending.GetComponent<SpriteRenderer> ().enabled = true;
					Ending.GetComponent<SpriteRenderer> ().sprite = DifferentEnd [2];
					Restart.GetComponent<SpriteRenderer> ().enabled = true;
					Restart.GetComponent<BoxCollider2D> ().enabled = true;
					Statics.actionsEnabled = false;
					Statics.ButtonsEnabled = false;
					GameObject.Find ("AirSire").GetComponent<AudioSource> ().enabled = true;

					Newspaper.GetComponent<SpriteRenderer> ().enabled = false;


				} else {
					//Ends with being fired as global oil addiction has not been achieved
					YearsSurvived.text = "IN BUSINESS FOR " + (Statics.year - 1950) + " Years";
					Ending.GetComponent<SpriteRenderer> ().enabled = true;
					Ending.GetComponent<SpriteRenderer> ().sprite = DifferentEnd [0];
					Restart.GetComponent<SpriteRenderer> ().enabled = true;
					Restart.GetComponent<BoxCollider2D> ().enabled = true;
					Statics.actionsEnabled = false;
					Statics.ButtonsEnabled = false;
					GameObject.Find ("RiotSound").GetComponent<AudioSource> ().enabled = true;

					Newspaper.GetComponent<SpriteRenderer> ().enabled = false;

				}

			} 
		} 

		if (Statics.OilDemand/Statics.OilSupply < 3) {
			//Resets the count when OilSupply is relatively high
			supplyDemandCount = 0;
		}

		if (Statics.InstantiateSmoke != null) {
			//Destroys the smoke from Siberia
			Destroy (Statics.InstantiateSmoke);
		} else if (Statics.InstantiateDestruction != null) {
			//Destroy (Statics.InstantiateDestruction);
		}

		Debug.Log (supplyDemandCount + " The supply demand count");
		Debug.Log(Statics.Region + " The region");


	}


	void Update ()
	{
		//This gigantic for statement compares and detects when an oil depesit has run out of oil, then changes the sprite animation on an oil well so that it is no longer pumping
		for (int i = 0; i < 28; i++) {
			if (Statics.OilQuantity [i] <= 0) {
				for (int y = 0; y < 1000; y++) {
					newOil [y] = Statics.OilWellBigTexas [y];
					if (newOil [y] != null && Statics.allEntity [i] != null) {
						Debug.Log ("Not Null");
						if (newOil [y].transform.position.x >= -Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x + Statics.allEntity [i].transform.position.x && newOil [y].transform.position.x <= Statics.allEntity [i].transform.position.x + Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x) {
							Instantiate (wellBigEmpty, newOil [y].transform.position, Quaternion.identity);
							//Destroys and creates
							Destroy (newOil [y]);
							Destroy (Statics.OilWellBigTexas [y]);
							Debug.Log ("Emptying Well");
							Statics.emptyWells++;
						}
					}
					newOil [y] = Statics.OilWellSmallTexas [y];
					if (newOil [y] != null && Statics.allEntity [i] != null) {
						Debug.Log ("Not Null");
						if (newOil [y].transform.position.x >= -Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x + Statics.allEntity [i].transform.position.x && newOil [y].transform.position.x <= Statics.allEntity [i].transform.position.x + Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x) {
							Instantiate (wellSmallEmpty, newOil [y].transform.position, Quaternion.identity);
							//Destroys and creates

							Destroy (newOil [y]);
							Destroy (Statics.OilWellSmallTexas [y]);
							Debug.Log ("Emptying Well");
							Statics.emptyWells++;
						}
					}

				}
			}
			Statics.OilQuantityEmpty [i] = false;
		}

		if (Input.GetMouseButtonDown (0) && Statics.thisActionEnabled5 == false) {
			//this sets the background and text for warning tab to be false
			Statics.actionsEnabled = true;
			Statics.thisActionEnabled5 = true;
			obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.0f);
			obj4.text = ("");
			obj2.GetComponent<SpriteRenderer> ().enabled = false;
		}

		//updates all the necessary information
		moneyLabel.text = ("BANK: $" + (int)Statics.money);
		oilLabel.text = ("Oil Price: $ " + (int)Statics.oilPrice);
		supplyLabel.text = ("" + (int)Statics.OilSupply);
		demandLabel.text = ("" + (int)Statics.OilDemand);

		//if (Statics.actionsEnabled == true) {
			
			if (startfade == true) {
				//Basically fades the scene after every year button click to visually see the difference
				//Debug.Log ("Fading");
				//This works by always having a white screen in front of the scene, and just resetting its color to white then fading it 
				alpha = alpha - 0.04f;
				white.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, alpha);

				if (white.GetComponent<SpriteRenderer> ().color.a <= 0.04) {
				//Stops the fade 
					//Debug.Log ("Fading2");
					startfade = false;
					white.GetComponent<SpriteRenderer> ().color = Color.clear;
					alpha = 1f;
			
				}




			//}
		}
	}
}

