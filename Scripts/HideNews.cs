using UnityEngine;
using System.Collections;

public class HideNews : MonoBehaviour {
	[HideInInspector]
	public GameObject Newspaper;
	public GameObject hideNewsButton;
	public Sprite OpenNewsButton = new Sprite();
	public Sprite HideNewsButton = new Sprite();
	private bool hide = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		if (Statics.actionsEnabled == true) {
			Debug.Log (Newspaper.GetComponent<SpriteRenderer> ().enabled);

			if (Newspaper.GetComponent<SpriteRenderer> ().enabled == true) {
				
				//Makes the newspaper invisible
				Newspaper.GetComponent<SpriteRenderer> ().enabled = false;
				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = OpenNewsButton;
				Debug.Log ("Hiding Newspaper");
				Debug.Log (Newspaper.GetComponent<SpriteRenderer> ().enabled);

			} else if (Newspaper.GetComponent<SpriteRenderer> ().enabled == false) {
				//Shows the newspaper
				Debug.Log ("Showing Newspaper");
				Newspaper.GetComponent<SpriteRenderer> ().enabled = true;
				hideNewsButton.GetComponent<SpriteRenderer> ().sprite = HideNewsButton;
			}
		}
	}
}
