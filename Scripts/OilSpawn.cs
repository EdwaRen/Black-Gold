using UnityEngine;
using System.Collections;

public class OilSpawn : MonoBehaviour {
	public int oilLength = Screen.width / 4;

	public int oilCount;
	GameObject OilThingy;

	public bool oilRedo = true;

	public Vector3 up = new Vector3(0, 100, 0);
	//public Sprite OilEntity;
	public GameObject test;
	public GameObject spawnLocation;

	public Sprite[] allOil = new Sprite[23];
	public GameObject[] allEntityBack = new GameObject[29];
	public GameObject[] allEntityPre = new GameObject[29];
	private Sprite dietSprite;

	public static bool movePlane = false;

	// Use this for initialization


	void Start () {
		//Screen.SetResolution (2000, 1600, false);
		//DontDestroyOnLoad (transform.gameObject);
		//Determine the Vector3 position for each oil entity



		if (Statics.firstTimeTexas == true) {
			//Ensures that at least 6 oil entities will be displayed
			while (oilRedo == true) {

				for (int i = 0; i < 28; i++) {
					//There are 28 possible locations for oil in the game, oilTrueTexas is at default all false hence no oil locations are enabled
					Statics.oilTrueTexas [i] = false;
					float randomNumber = Random.Range (-1, 3);
					if (randomNumber == 0 || randomNumber == 1) {
						//This determines which of the 28 will be enabled
						Statics.oilTrueTexas [i] = true;
						oilCount++;
						//RandomNum2 decides what type of oil will be found from one of 4, large, mediume, medium2, or small
						Statics.randomNumber2[i] = Random.Range (1, 5);
						//Shows an appropriate sprite for oil deposit size
						Statics.spriteNumTexas[i] =(int) Statics.randomNumber2[i] * 6 - 6;
						//Dictates the size of the oil deposit
						Statics.OilQuantity [i] = Statics.randomNumber2[i] * 40 +40;


					} else {
						Statics.oilTrueTexas [i] = false;
					}


				}

				if (oilCount > 24) {
					//Ensures at least 24 oil deposits for a less boring experience
					oilRedo = false;

				}
				oilCount = 0;


			}
			Statics.firstTimeTexas = false;
		}

		for (int i = 0; i < 28; i++) {

			if (Statics.oilTrueTexas[i] == true) {
				//Sets the sprites and the locations of the spawnedd oil
				dietSprite = allOil [Statics.spriteNumTexas[i]];
				//Makes sure the oil is not spawned in the middle of nowhere
				if (i < 7) {
					Statics.oilPosTexas [i] = new Vector3 (spawnLocation.transform.position.x + 4 * i, spawnLocation.transform.position.y, 1);
				} else if (i < 14 && i > 6) {
					Statics.oilPosTexas [i] = new Vector3 (spawnLocation.transform.position.x + (4 * (i -7)) + 45, spawnLocation.transform.position.y, 1);
				} else if (i < 21 && i > 13) {
					Statics.oilPosTexas [i] = new Vector3 (spawnLocation.transform.position.x + (4 * (i -14)) + 90, spawnLocation.transform.position.y, 1);
				} else if (i < 28 && i > 20) {
					Statics.oilPosTexas [i] = new Vector3 (spawnLocation.transform.position.x + (4 * (i -21)) + 135, spawnLocation.transform.position.y, 1);
				}

				allEntityPre [i].transform.position =Statics. oilPosTexas [i];

				allEntityPre [i].transform.localScale = new Vector3 (6, 6, 1);
				allEntityPre [i].GetComponent<SpriteRenderer> ().sprite = dietSprite;
				//The oil background gameobject is an empty sprite of the chosen oil deposit texture. This is placed behind the oil deposit so that the player can see the oil levels decreasing
				GameObject OilBackground = (GameObject) Instantiate (allEntityPre [i], new Vector3(allEntityPre[i].transform.position.x, spawnLocation.transform.position.y, 1.3f), Quaternion.identity);
				OilBackground.GetComponent<SpriteRenderer> ().sprite = allOil[Statics.spriteNumTexas[i] + 5];
				Statics.allEntity [i] = (GameObject) Instantiate (allEntityPre [i], allEntityPre [i].transform.position, Quaternion.identity);
				//For simplicity, instead of creating two variables, I just doubled the size of one and put the oil background at the end of the original oil deposit information
				Statics.allEntity [i + 28] = (GameObject) Instantiate (OilBackground, OilBackground.transform.position, Quaternion.identity);
				//Oil deposits are invisible by default until discovered
				Statics.allEntity [i].GetComponent<SpriteRenderer> ().enabled = false;
				Statics.allEntity [i+28].GetComponent<SpriteRenderer> ().enabled = false;
				//Since a copy of the information is already stored in a global variable, there is no more need of this local variable
				Destroy (OilBackground);
			}
		}

		for (int i = 1; i < 23; i++) {
			Statics.allOilCopy [i] = allOil [i];
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
