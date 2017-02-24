using UnityEngine;
using System.Collections;

public class Camera2DMove : MonoBehaviour {
	// Use this for initialization
	public GameObject cancelCanvas;
	//public GameObject Camera = new GameObject();
	private float posX = new float();
	private float posXPre = new float();
	public string caller;
	public GameObject Siberia;
	public GameObject Iraq;



	void Start () {
		//NUBTSTD
		Statics.CameraOriginalPos = transform.position;
		//posX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//MoveElements true is needs to be moved

		if (Statics.timeRemaining <= 0) {
			//Ensures that the cash spawned in the election tab gets destroyed (reduces lag)
			Destroy (GameObject.Find ("WadCash(Clone)"));
		}

		if (Statics.moveTo == "Texas") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			posXPre = transform.position.x;
			//Sets some sound for each scene
			GameObject.Find ("Background").GetComponent<AudioSource> ().enabled = true;

			gameObject.transform.Translate (new Vector3 ((-posXPre), 0, 0));
			posX = transform.position.x;


			//Debug.Log (transform.position.x + " PosXPre " + gameObject);
			Statics.moveTo = "";

		} else if (Statics.moveTo == "Alberta") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			//Sets some sound
			GameObject.Find ("Background (1)").GetComponent<AudioSource> ().enabled = true;

			posXPre = transform.position.x;
			gameObject.transform.Translate (new Vector3 (45 - posXPre, 0, 0));
			posX = transform.position.x;
			//Debug.Log (transform.position.x + " PosXPre " + gameObject);
			Statics.moveTo = "";
		} else if (Statics.moveTo == "Siberia") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			//Sets some sound
			if (Statics.SiberiaEnd == false) {
				//Pre and After regime change background music
				GameObject.Find ("Background (2)").GetComponent<AudioSource> ().enabled = true;
			} else {
				GameObject.Find ("Background_13 (2)").GetComponent<AudioSource> ().enabled = true;

			}
			posXPre = transform.position.x;
			gameObject.transform.Translate (new Vector3 (90 - posXPre, 0, 0));
			posX = transform.position.x;
			//Debug.Log (transform.position.x + " PosXPre " + gameObject);
			Statics.moveTo = "";
		} else if (Statics.moveTo == "Iraq") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			//Sets some sound
			GameObject.Find("Background (3)").GetComponent<AudioSource> ().enabled = true;
			posXPre = transform.position.x;
			gameObject.transform.Translate (new Vector3 (135 - posXPre, 0, 0));
			posX = transform.position.x;
			//Debug.Log (transform.position.x + " PosXPre " + gameObject);
			Statics.moveTo = "";
		} else if (Statics.moveTo == "HQ") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			//Sets some sound
			GameObject.Find("Background_14 (4)").GetComponent<AudioSource> ().enabled = true;

			posXPre = transform.position.x;
			gameObject.transform.Translate (new Vector3 (180 - posXPre, 0, 0));
			posX = transform.position.x;
			cancelCanvas.GetComponent<Canvas> ().enabled = true;
			Statics.actionsEnabled = true;
			Statics.ButtonsEnabled = false;
			Statics.moveTo = "";

		} else if (Statics.moveTo == "Election") {
			//Changes the camera position and posX defines the limits to how far one could scroll sideways
			//Sets some sound
			//Time remaining is the amount of time in each election tab
			Statics.timeRemaining = 8f;
			GameObject.Find("Election").GetComponent<AudioSource> ().enabled = true;

			Statics.pleaseNoClick = false;
			posXPre = transform.position.x;
			gameObject.transform.Translate (new Vector3 (225 - posXPre, 0, 0));
			posX = transform.position.x;
			Statics.moveTo = "";
		}

		if (Statics.Region != "Siberia") {
			//Restores the sound after an election year
			GameObject.Find("Background (2)").GetComponent<AudioSource> ().enabled = false;
			GameObject.Find ("Background_13 (2)").GetComponent<AudioSource> ().enabled = false;

		} 
		if (Statics.Region != "Iraq") {
			//Restores the sound after an election year

			GameObject.Find("Background (3)").GetComponent<AudioSource> ().enabled = false;
		}
		if (Statics.Region != "HQ") {
			//Restores the sound after an election year

			GameObject.Find("Background_14 (4)").GetComponent<AudioSource> ().enabled = false;
		}
		if (Statics.Region != "Alberta") {
			//Restores the sound after an election year

			GameObject.Find("Background (1)").GetComponent<AudioSource> ().enabled = false;
		}
		if (Statics.Region != "Texas") {
			//Restores the sound after an election year

			Debug.Log ("No Texas");
			Debug.Log (Statics.Region);

			GameObject.Find("Background").GetComponent<AudioSource> ().enabled = false;
		}
		if (Statics.Region != "Election") {
			//Enables the sound during an election year

			GameObject.Find("Election").GetComponent<AudioSource> ().enabled = false;
		}
		/*
		if (Statics.Region == "Siberia") {
			GameObject.Find ("Background (2)").GetComponent<AudioSource> ().enabled = true;
		}*/


		//posX = transform.position.x;

		//Debug.Log (GameObject.Find ("ComputerScreen").transform.position + " computer Position");
		//Debug.Log (posX + (float) 16 + " Right cap ");

		if (transform.position.x > posX + 16) {
			//The booleans test and test2 ensure that one can not scroll too much so as to avoid unpainted graphics
			Statics.test = false;
			Statics.test2 = true;
		} else {
			Statics.test = true;
		}
		if (transform.position.x < posX) {
			Statics.test2 = false;
			Statics.test = true;
		} else {
			Statics.test2 = true;
		}

		//Detects the right key and ensures that it can not be pressed during Election and HQ tabs
		if(Input.GetKey(KeyCode.RightArrow) && Statics.test == true && Statics.Region != "HQ" && Statics.Region!= "Election")
		{
			//Transforms all elements that the script is attached to by the specified amount
			transform.Translate(new Vector3(Statics.speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow)&& Statics.test2 == true && Statics.Region != "HQ" && Statics.Region!= "Election")
		{			
			//Transforms all elements that the script is attached to by the specified amount
			
			transform.Translate(new Vector3(-Statics.speed * Time.deltaTime,0,0));
		}
		/*
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}
	*/
	}
}
