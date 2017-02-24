using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;
	public bool reverseScale = false;
	private float spriteWidth = 0f;
	private Camera cam;
	private Transform myTransform;
	private int moveCount = 0;
	private int moveCount2 = 0;

	void Awake() {
		cam = Camera.main;
		myTransform = transform;

	}

	// Use this for initialization
	void Start () {
		//SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		//spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {

		moveCount++;
		moveCount2++;
		//Debug.Log (moveCount2);
		if (moveCount2 == 1700) {
			moveCount2 = 0;

			MakeNewBuddy (1);
			Destroy (gameObject, 1);

		}

		if (moveCount == 1) {
			transform.localScale = new Vector3((float) 4.05, (float)5.64, 0);
			transform.Translate (1f * Time.deltaTime, 0, 0);
			//Vector3 newpos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			//transform.position = Vector3.Lerp (transform.position, newpos, 0.5); 
			moveCount = 0;
			//floatingRock.transform.position = Vector3.Lerp (startPosition.transform.position, endPosition.transform.position, step);
		}



	}

	//A function that creates a buddy on the side required
	void MakeNewBuddy (int rightOrLeft) {
		//Calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (-14 , myTransform.position.y, myTransform.position.z);
		//Instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate  (transform, newPosition, myTransform.rotation) as Transform;

		newBuddy.parent = myTransform.parent;


	}

}
