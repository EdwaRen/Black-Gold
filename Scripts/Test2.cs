using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {
	public string scene;
	public Vector3 up = new Vector3(0, 100, 0);
	public Vector3 down = new Vector3(0, -100, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		//Fades out the scene and prepares the main gaming scene
		Initiate.Fade (scene, Color.black, 3f);
		Statics.Region = "Texas";
		Statics.moveTo = "Texas";
	}
		
	void OnMouseEnter() {
		//GetComponent<SpriteRenderer> ().color = Color;
		//gameObject.transform.Translate(up, Space.World);
	}

	void OnMouseExit() {
		//GetComponent<SpriteRenderer> ().color = Color;
		//gameObject.transform.Translate(down, Space.World);
	}
}
