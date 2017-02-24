using UnityEngine;
using System.Collections;
using System;
public class ResetStatics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Basically resets all the global variables so that everything will be back to normal when the restart button is clicked

		//COre
		Statics.money = 2000;
		Statics.oilPrice = 13;
		Statics.totalWells = 0;
		Statics.OilDemand = 20;
		Statics.OilSupply = 0;
		Statics.Region = "Texas";

		//Changing Scnes
		Statics.moveTo = "Texas";
		Statics.moveElements =new bool[] {true, true, true};
		Statics.moveElements [0] = true;
		Statics.moveElements [1] = true;
		Statics.moveElements [2] = true;

		Statics.lastPos = new float[2];


		Statics.siberiaEnabled = false;
		Statics.iraqEnabled = false;

		Statics.year = 1950;
		//Camera Moving
		Statics.test = true;
		Statics.test2 = true;
		Statics.speed = 10.0f;

		//Texas Oil Entities
		Statics.oilTrueTexas = new bool[29];
		Statics.oilPosTexas = new Vector3[29];
		Statics.firstTimeTexas = true;

		Statics.spriteNumTexas = new int[29];

		Statics.oilWellBoolTexas = new bool[29];

		Statics.OilWellBigTexas = new GameObject[1000];

		Statics.OilWellSmallTexas = new GameObject[1000];

		Statics.OilWellBigTexasInt = 0;
		Statics.OilWellSmallTexasInt = 0;
		Statics.OilQuantityEmpty = new bool[29];


		Statics.allEntity = new GameObject[60];

		Statics.OilNumWells = new float[29];

		Statics.OilQuantity = new float[29];

		Statics.randomNumber2 = new float[29] ;

		Statics.OilLarge = 200;		
		Statics.OilMedium2 = 160;					
		Statics.OilMedium1 = 120;					
		Statics.OilSmall = 80;					
		Statics.allOilCopy = new Sprite[23];


		//News and Elections
		Statics.PercentDem = 50;
		Statics.PercentRep = 50;
		Statics.OilFriendly = false;
		Statics.moneySpent = 0;
		Statics.pleaseNoClick = false;
		//Statics.govNews;
		Statics.ActionNews = false;
		Statics.ActionClickCount = 0;
		Statics.timeRemaining = 8f;

		//Siberia + Iraq
		//Statics.SiberiaYear;
		Statics.SiberiaBombed = false;
		//Statics.InstantiateSmoke;
		Statics.SiberiaEnd = false;
//		Statics.InstantiateDestruction;
		Statics.IraqEnd = false;



		//Menu Stuff
		Statics.returnOriginal = true;
		//Statics.ActionButtonClick;
		//This identifies that all buttons should be enabled or disabled
		Statics.actionsEnabled = true;
		Statics.ButtonsEnabled = true;

		//This makes sure that at least one button is always enabled. Also restricts buttons to be activated once at a time
		Statics.thisActionEnabled = true;
		Statics.thisActionEnabled2 = true;
		Statics.thisActionEnabled3 = true;
		Statics.thisActionEnabled4 = true;
		Statics.thisActionEnabled5 = true;
		Statics.thisACtionEnabled6 = true;

		//Statics.planeStatic;

		Statics.movePlane = false;
		//Statics.instantiateWellBig;

		//Camera Stuff
		//Statics.CameraOriginalPos;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
