using UnityEngine;
using System.Collections;
//USELESS UNUSED STUFF
public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds; //Array of all the background and foreground
	public float[] parallaxScales; //Proportion of the camera's movement
	public float smoothing = 1f; //How smooth the parallax is gonna b

	public Transform cam; //Reference to main camera's transform
	public Vector3 previousCamPos; //Store position of the camera previos frame

	//Is called before Start()
	void Awake () {
		//Set up the reference camera
		cam = Camera.main.transform;

	}

	// Use this for initialization
	void Start () {
		
		//DontDestroyOnLoad (transform.gameObject);
		//The previous frame had the current frame's camera position
		previousCamPos = cam.position;
		parallaxScales = new float[backgrounds.Length];

		//Assigning corresponding parallaxScales
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds[i].position.z * -1;
		}

	}

	// Update is called once per frame
	void Update () {
		//FOr each background
		for (int i = 0; i < backgrounds.Length; i++) {
			// The parallax is the opposite of the camera movement
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//Set a target x position which is the current position
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;


			//Create a target position which is the background...

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//Fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

			//Set previousCamPos to the camera's position at the end


		}

		previousCamPos = cam.position;

	}
}
