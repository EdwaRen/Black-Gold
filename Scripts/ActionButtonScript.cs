using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ActionButtonScript : MonoBehaviour {
	//public string scene;
	public Sprite Changed = new Sprite();
	public Sprite Original = new Sprite();
	public string DetailsString;
	public Text DetailsEntity;
	private string previousText;
	public string actionName;
	private bool doNotReEnter = false;

	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject InstantiateWellBig;
	public GameObject InstantiateWellSmall;
	public GameObject realWell;
	public GameObject fakeWell;
	public Text obj4;
	public Text obj5;

	public GameObject InstantiateObj;
	public GameObject InstantiateSpin;
	private GameObject InstantiateShade;
	private GameObject InstantiatePipe;
	public float xMove;
	public float leftMove;
	private bool firstTime = true;
	public GameObject referencePipe;
	private int[] bannedNumbers = new int[7];
	private float moveStart = -9f;
	private float moveStartLimit = 24;
	private bool planeCreated = false;
	public GameObject thePlane;
	public bool WellBigGone = false;

	// Use this for initialization
	void Start () {
		Statics.movePlane = false;
		previousText = DetailsEntity.text;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (WellBigGone);
		if (WellBigGone == true) {
			Destroy (InstantiateWellBig);
			Destroy (GameObject.Find("UselessOil"));
		}

		if (actionName == "WellBig" && Statics.actionsEnabled == false && Statics.thisActionEnabled2 == false) {
			//Finds the mouse position and moves the oil well to be built along with it across the x axis. Also creates a shader to highlight where it is
			//Debug.Log ("Well Big being updated");
			Vector3 mousePosition = new Vector3 ();
			mousePosition = Input.mousePosition;
			Vector3 mouseTargetPre = new Vector3 ();
			mouseTargetPre = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, InstantiateShade.transform.position.y, 0));
			Vector3 mouseTarget = (new Vector3 (mouseTargetPre.x, InstantiateShade.transform.position.y, 0));


			InstantiateShade.transform.position = new Vector3 (mouseTarget.x , InstantiateShade.transform.position.y, 0);
			InstantiateWellBig.transform.position = new Vector3 (mouseTarget.x , InstantiateWellBig.transform.position.y, 1.1f);

		} else if (actionName == "WellSmall" && Statics.actionsEnabled == false && Statics.thisActionEnabled4 == false) {
			//Finds the mouse position and moves the oil well to be built along with it across the x axis. Also creates a shader to highlight where it is
			//Debug.Log ("Well Small being updated");
			Vector3 mousePosition = new Vector3 ();
			mousePosition = Input.mousePosition;
			Vector3 mouseTarget = new Vector3 ();
			mouseTarget = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, InstantiateShade.transform.position.y, 0));
			InstantiateShade.transform.position = new Vector3 (mouseTarget.x, InstantiateShade.transform.position.y, 0);
			InstantiateWellSmall.transform.position = new Vector3 (mouseTarget.x, InstantiateWellSmall.transform.position.y, 1.1f);
		}

		if (Input.GetKeyDown ("escape") && actionName == "WellBig" ) {
			WellBigGone = true;
			//When the escape key is hit, it makes the shader disappear and cancels the effect
			Statics.actionsEnabled = true;
			Statics.thisActionEnabled2 = true;
			Destroy (GameObject.Find("ShaderHighlight(Clone)"));
			Destroy (InstantiateWellBig);
			transform.GetComponent<SpriteRenderer> ().sprite = Original;
			DetailsEntity.text = "Big Well";

		} else if (Input.GetKeyDown ("escape") && actionName == "WellSmall") {
			//When escape key is hit, game returns to normalcy
			Statics.actionsEnabled = true;
			Statics.thisActionEnabled4 = true;
			Destroy (InstantiateShade);
			Destroy (InstantiateWellSmall);
			transform.GetComponent<SpriteRenderer> ().sprite = Original;
			DetailsEntity.text = previousText;
		}
		if (Input.GetMouseButtonDown (0) && actionName == "WellBig" && Statics.thisActionEnabled2 == false && Statics.money > 0) {
			//Removes the old well that was used for positioning purposes and creates a new one with full animations
			Statics.OilWellBigTexas[Statics.OilWellBigTexasInt] = (GameObject) (Instantiate(obj2, new Vector3((float)InstantiateWellBig.transform.position.x, (float)InstantiateWellBig.transform.position.y, (float)InstantiateWellBig.transform.position.z + 0.1f ), Quaternion.identity));
			Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].name = "Idle Oil";
			Statics.money =Statics.money - 700;

			for (int i = 0; i < 28; i++) {
				//THis for loop checks if the posiiton of an oil well overlaps that of an oil deposit
				if (Statics.oilTrueTexas [i] == true) {
					
					Debug.Log (Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].transform.position.x + "The position");

					//Debug.Log (Statics.OilWellBigTexasInt);
					if (Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].transform.position.x >= -Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x + Statics.allEntity [i].transform.position.x && Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].transform.position.x <= Statics.allEntity [i].transform.position.x + Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x) {
						//If the oil well has an overlap, it has an added pumping animation and the oil level in the deposit decreases incrementlly
						Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].name = "UselessOil";

						Debug.Log ("BOOYAH2.0");
						Statics.OilNumWells [i] = Statics.OilNumWells [i] + 2;
						//Destroy (Statics.OilWellBigTexas [Statics.OilWellBigTexasInt]);
						//Destroy(InstantiateWellBig);
						Statics.OilWellBigTexas [Statics.OilWellBigTexasInt] = (GameObject) Instantiate (realWell, InstantiateWellBig.transform.position, Quaternion.identity);
						Statics.OilWellBigTexas [Statics.OilWellBigTexasInt].name = "Pumping Oil";
						//Instantiate (realWell, InstantiateWellBig.transform.position, Quaternion.identity);
						Statics.totalWells++;
						//Sets the oil deposit to visible if it has not been already
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().enabled = true;
						Statics.allEntity [i+28].GetComponent<SpriteRenderer> ().enabled = true;
					}
				}
			}
			//Adds this well to a list
			Statics.OilWellBigTexasInt++;


		} else if (Input.GetMouseButtonDown (0) && actionName == "WellSmall" && Statics.thisActionEnabled4 == false && Statics.money > 0) {
			//Does mostly the same stuff as the Bigwell if statement
			Statics.money = Statics.money - 400;
			Debug.Log(Statics.OilWellSmallTexasInt);

			//Actually creates the well instead of displaying it in a temporary variable

			Statics.OilWellSmallTexas[Statics.OilWellSmallTexasInt] = (GameObject) (Instantiate(obj2, new Vector3((float)InstantiateWellSmall.transform.position.x, (float)InstantiateWellSmall.transform.position.y, (float)InstantiateWellSmall.transform.position.z + 0.1f ), Quaternion.identity));
			Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt].name = "Idle Oil";

			for (int i = 0; i < 28; i++) {
				if (Statics.oilTrueTexas [i] == true) {
					//Debug.Log ("BOOYAH");
					if (Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt].transform.position.x  >= -Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x + Statics.allEntity [i].transform.position.x  && Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt].transform.position.x   <= Statics.allEntity [i].transform.position.x + Statics.allEntity [i].GetComponent<SpriteRenderer> ().bounds.extents.x) {
						//Detects overlap between oil well and oil deposit
						Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt].name = "UselessOil";

						Statics.OilNumWells [i] = Statics.OilNumWells [i] + 1;
						Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt] = (GameObject) Instantiate (realWell, InstantiateWellSmall.transform.position, Quaternion.identity);
						Statics.OilWellSmallTexas [Statics.OilWellSmallTexasInt].name = "Pumping Oil";

						Statics.totalWells++;
						Statics.allEntity [i].GetComponent<SpriteRenderer> ().enabled = true;
						Statics.allEntity [i+28].GetComponent<SpriteRenderer> ().enabled = true;
					}
				}
			}
			Statics.OilWellSmallTexasInt++;

		} else if (Input.GetMouseButtonDown(0) && actionName == "Info" && Statics.thisActionEnabled3 == false) {
			//Closes the info tab
			obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.0f);
			Statics.actionsEnabled = true;
			Statics.thisActionEnabled3 = true;
			obj4.text = "";
			//Destroy ((InstantiateObj as GameObject).gameObject);
			obj2.GetComponent<SpriteRenderer> ().enabled = false;
			//GameObject.Find ("TextBackground").GetComponent<SpriteRenderer> ().enabled = false;

		}

		if (Statics.movePlane == true && actionName == "Prospect") {
			//Animates the plane so that it flies from left to right and then repeats forever 
			//Debug.Log ("movePlane is true and instantiated");
			Statics.planeStatic.transform.Translate (4f * Time.deltaTime, 0, 0);
			if (Statics.planeStatic.transform.position.x >= moveStartLimit) {
				Statics.planeStatic.transform.position = new Vector3(moveStart, 0, -.09f);
			}

		
				
		}


	}

	void OnMouseEnter() {
		if (Statics.actionsEnabled == true && Statics.ButtonsEnabled == true) {
			//Changes the button sprite to become another colour
			transform.GetComponent<SpriteRenderer> ().sprite = Changed;
			previousText = DetailsEntity.text;
			DetailsEntity.text = DetailsString;
		}
	}


	void OnMouseExit() {
		if (Statics.actionsEnabled == true && Statics.ButtonsEnabled == true) {
			//Changes the sprite so that its color becomes its original one again
			transform.GetComponent<SpriteRenderer> ().sprite = Original;
			DetailsEntity.text = previousText;
		}
			

	}

	void OnMouseDown() {
		//TestText.GetComponent<Text> ().text = ("Hello World");


	}
	void OnMouseUp() {
		if (Statics.ButtonsEnabled == false) {
			//Shows the Info tab and makes its background display visible for HQ, since it needs special functions as buttons for construction need to be disabled
			if (actionName == "Info" && Statics.thisActionEnabled3 == true) {
				obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.4f);
				Statics.actionsEnabled = false;
				obj4.text = ("At corporate headquarters, we can use the government's 'help' to ensure diversified petroleum assets. In order to receive help, donations must be made to a political party in a 10 year election. Then, click the bunker below our headquarters to access government ressources");
				obj2.GetComponent<SpriteRenderer> ().enabled = true;
				Statics.thisActionEnabled3 = false;
			}
		} else if (Statics.actionsEnabled == true) {
			
			//Assigns a variable so we know which button has been clicked
			Statics.ActionButtonClick = actionName;
			if (actionName == "Info" && Statics.thisActionEnabled3 == true) {
				//Loads Makes a background sprite visible and fills some text about the region
				obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.4f);
				//Setting actionsEnabled to false ensures other buttons can not be pressed at the moment
				Statics.actionsEnabled = false;
				//Discriptions change by region
				if (Statics.Region == "Texas") {
					obj4.text = ("Texas has been the centerpiece of the modern american oil industry. Decades of our corporate work here has shown these people about all sorts of benefits that come with the oil industry as long as they ignore negligible issues such as widepsread pollution or a heightened risk of lung cancer.");
				} else if (Statics.Region == "Alberta") {
					obj4.text = ("The Albertan oil sands is a relatively new frontier for petroleum exploration, it does however hold lots of potential and there are tons of it in Alberta.");
				} else if (Statics.Region == "Siberia") {
					obj4.text = ("The Soviet Union is currently acting like a pampered kid that does not let anyone else touch his stuff. Because of this, we are unable to exploit their fine oil, unless... if can get close with our government friends at HQ.");
				} else if (Statics.Region == "Iraq") {
					obj4.text = ("Iraq is that type of arrogant kid who loves to brag about stuff that he does not have. Iraq has not opened its ressources to foreign corporations, however Iraq may end up changing their mind if we get our friends at HQ to forcefully impose democracy down their throat");
				}

				//Sets some background stuff to make the text more clear to true
				obj2.GetComponent<SpriteRenderer> ().enabled = true;
				Statics.thisActionEnabled3 = false;
				Statics.actionsEnabled = false;

			} else if (actionName == "Cursor") {
				//replaced by tutorial
			} else if (actionName == "Prospect" && Statics.thisActionEnabled == true && Statics.money > 0) {
				//The first if statement ensures that this action can not be taken in SIberia and Iraq prior to regime change
				if (Statics.Region == "Siberia" && Statics.SiberiaEnd == false) {
				} else if (Statics.Region == "Iraq" && Statics.IraqEnd == false) {
				} else {

					Statics.money = Statics.money - 100;
					//Creates a plane that shows an animation scanning for oil
					//The following lines ensures that the prospect action will take place with oil deposits in the current region and the plane will not move offscreen
					if (Statics.Region == "Texas") {
						moveStart = -9f;
						moveStartLimit = 24;
					} else if (Statics.Region == "Alberta") {
						moveStart = 36;
						moveStartLimit = 69;
					} else if (Statics.Region == "Siberia") {
						moveStart = 81;
						moveStartLimit = 114;
					} else if (Statics.Region == "Iraq") {
						moveStart = 126;
						moveStartLimit = 159;
					}
					//thePlane = (GameObject) InstantiateObj = (GameObject)Instantiate (obj1, new Vector3 (moveStart, 0, -0.09f), Quaternion.identity);
					Statics.planeStatic = (GameObject)obj1;
					Statics.planeStatic.transform.position = new Vector3 ((moveStart), 0, -0.09f);
					//Makes the plane visible
					Statics.planeStatic.GetComponent<SpriteRenderer> ().enabled = true;

					Statics.movePlane = true;
					//Shows that this level is currently busy
					//InstantiateSpin = (GameObject)Instantiate (obj3, new Vector3(-4.317f, -2.323f, -0.9f), Quaternion.identity);
					//Statics.thisActionEnabled = false;

					//This plane randomly reveals 3 oil deposits in a specified region with no replacement
					for (int i = 0; i <= 2; i++) {
						int randomReveal = 0;

						if (Statics.Region == "Texas") {
							randomReveal = Random.Range (0, 7);
						} else if (Statics.Region == "Alberta") {
							randomReveal = Random.Range (7, 14);
						} else if (Statics.Region == "Siberia" && Statics.SiberiaEnd == true) {
							randomReveal = Random.Range (14, 21);
						} else if (Statics.Region == "Iraq" && Statics.IraqEnd == true) {
							randomReveal = Random.Range (21, 28);
						}
						//randomReveal = Random.Range (0, 7);

						if (Statics.oilTrueTexas [randomReveal] == true) {
							//Sets hte oil deposit entity to true
							Statics.allEntity [randomReveal].GetComponent<SpriteRenderer> ().enabled = true;
						}
					}
				}

			} else if (actionName == "WellBig" && Statics.thisActionEnabled2 == true) {
				//Ensures this action cant be taken too early on
				if (Statics.Region == "Siberia" && Statics.SiberiaEnd == false) {
				} else if (Statics.Region == "Iraq" && Statics.IraqEnd == false) {
				} else {
					WellBigGone = false;
					//Changes the buttons labeling text
					previousText = DetailsEntity.text;
					//Creates a shader and an oil well
					//creatas a shader and a placement well
					InstantiateShade = (GameObject)Instantiate (obj1, new Vector3 (0, 1.87f, 0f), Quaternion.identity);
					InstantiateWellBig = (GameObject)Instantiate (obj2, new Vector3 (0, obj2.transform.position.y, 1.3f), Quaternion.identity);
					Statics.thisActionEnabled2 = false;
					Statics.actionsEnabled = false;
				}

			} else if (actionName == "WellSmall" && Statics.thisActionEnabled4 == true) {
				//Ensures this action cant be taken too early
				if (Statics.Region == "Siberia" && Statics.SiberiaEnd == false) {
				} else if (Statics.Region == "Iraq" && Statics.IraqEnd == false) {
				} else {

					previousText = DetailsEntity.text;


					//Creates a shader and a placement well
					InstantiateShade = (GameObject)Instantiate (obj1, new Vector3 (0, 1.87f, 0f), Quaternion.identity);
					InstantiateWellSmall = (GameObject)Instantiate (obj2, new Vector3 (0, obj2.transform.position.y, 1.3f), Quaternion.identity);

					Statics.thisActionEnabled4 = false;
					Statics.actionsEnabled = false;
				}
			} else if (actionName == "Tutorial") {
				//Opens the online tutorial
				Debug.Log ("URL OPENED WTF");
				Application.OpenURL ("https://justpaste.it/SleepIsForTheWeak");
			}

		}else if (Statics.actionsEnabled == false) {

			//Statics.returnOriginal = false;
			Statics.ActionButtonClick = actionName;
			if (actionName == "Info" && Statics.thisActionEnabled3 == false) {
				/*
				obj1.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.0f);
				Statics.actionsEnabled = true;
				Statics.thisActionEnabled3 = true;
				obj4.text = "";
				//Destroy ((InstantiateObj as GameObject).gameObject);
				obj2.GetComponent<SpriteRenderer> ().enabled = false;
				//GameObject.Find ("TextBackground").GetComponent<SpriteRenderer> ().enabled = false;
*/
			} else if (actionName == "Cursor") {

			} else if (actionName == "Prospect") {

			} else if (actionName == "WellBig") {

			} else if (actionName == "WellSmall") {

			}
		}
			

	}




}
