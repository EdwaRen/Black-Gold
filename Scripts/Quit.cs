﻿using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseUp() {
		//Quites the game
		Application.Quit();
	}
}


