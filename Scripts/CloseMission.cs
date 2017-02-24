using UnityEngine;
using System.Collections;

public class CloseMission : MonoBehaviour {
	//This code is used at HQ to return the scene to normal to before you clicked the bunker below headquarters
	public GameObject CloseButton;
	public Sprite OriginalButton;
	public Sprite ChangedButton;
	public GameObject DisableBack;
	public GameObject evilMap;
	public GameObject MissionClick;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseEnter() {
		//Changes sprites on mouseover
		CloseButton.GetComponent<SpriteRenderer> ().sprite = ChangedButton;
	}

	void OnMouseExit() {
		CloseButton.GetComponent<SpriteRenderer> ().sprite = OriginalButton;
	}

	void OnMouseUp() {
		//Closes the mission control sprites that include the map, manila folder and description
		CloseButton.GetComponent<SpriteRenderer> ().enabled = false;
		CloseButton.GetComponent<BoxCollider2D> ().enabled = false;
		DisableBack.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 0.0f);
		evilMap.GetComponent<SpriteRenderer> ().enabled = false;
		MissionClick.GetComponent<SpriteRenderer> ().enabled = false;
		MissionClick.GetComponent<BoxCollider2D> ().enabled = false;
		//You can click buttons again with this
		Statics.actionsEnabled = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
