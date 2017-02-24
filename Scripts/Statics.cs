using UnityEngine;
using System.Collections;

public class Statics : MonoBehaviour {
	//All the global variables are placed here

	public static float money = 2000;
	public static float oilPrice = 13;
	public static float totalWells = 0;
	public static float OilDemand = 20;
	public static float OilSupply = 0;
	public static string Region = "";

	//Changing Scnes
	public static string moveTo = "";
	public static bool[] moveElements =new bool[] {true, true, true};
	public static float[] lastPos = new float[2];
	public static bool siberiaEnabled = false;
	public static bool iraqEnabled = false;

	public static float year = 1950;
	//Camera Moving
	public static bool test = true;
	public static bool test2 = true;
	public static float speed = 10.0f;

	//Variables related to oil deposits
	//Determines if a set location has oil
	public static bool[] oilTrueTexas = new bool[29];
	//Stores the position of the oil deposit
	public static Vector3[] oilPosTexas = new Vector3[29];
	public static bool firstTimeTexas = true;
	//The sprite for each oil deposit
	public static int[] spriteNumTexas = new int[29];
	public static bool[] oilWellBoolTexas = new bool[29];
	//Each oil well is stored as a gameobject here
	public static GameObject[] OilWellBigTexas = new GameObject[1000];
	public static GameObject[] OilWellSmallTexas = new GameObject[1000];
	//counts the number of created wells
	public static int OilWellBigTexasInt = 0;
	public static int OilWellSmallTexasInt = 0;
	//Records empty wells
	public static bool[] OilQuantityEmpty = new bool[29];

	//Gameobject for all oil deposits as well as their variation states
	public static GameObject[] allEntity = new GameObject[60];

	//Oil wells by production, a big well is worth 2 small wells
	public static float[] OilNumWells = new float[29];
	//Stores the quantity of oil left
	public static float[] OilQuantity = new float[29];
	public static float[] randomNumber2 = new float[29] ;
	//Stores the amount of oil in each type of deposit
	public static float OilLarge = 200;		
	public static float OilMedium2 = 160;					
	public static float OilMedium1 = 120;					
	public static float OilSmall = 80;					
	public static Sprite[] allOilCopy = new Sprite[23];
	public static float emptyWells = 0;

	//News and Elections
	public static float PercentDem = 50;
	public static float PercentRep = 50;
	public static bool OilFriendly = false;
	public static float moneySpent = 0;
	public static bool pleaseNoClick = false;
	//Determines if a certain year needs news from the government
	public static float govNews;
	public static bool ActionNews = false;
	//Records how many missions have been completed
	public static int ActionClickCount = 0;
	public static float timeRemaining = 8f;

	//Siberia + Iraq
	public static float SiberiaYear;
	public static bool SiberiaBombed = false;
	public static GameObject InstantiateSmoke;
	//Records if Siberia events are finished and if oil wells can be constructed there
	public static bool SiberiaEnd = false;
	public static GameObject InstantiateDestruction;
	public static bool IraqEnd = false;

	//Menu Stuff
	public static bool returnOriginal = true;
	public static string ActionButtonClick;
	//This identifies that all buttons should be enabled or disabled
	public static bool actionsEnabled = true;
	public static bool ButtonsEnabled = true;

	//This makes sure that at least one button is always enabled. Also restricts buttons to be activated once at a time
	public static bool thisActionEnabled = true;
	public static bool thisActionEnabled2 = true;
	public static bool thisActionEnabled3 = true;
	public static bool thisActionEnabled4 = true;
	public static bool thisActionEnabled5 = true;
	public static bool thisACtionEnabled6 = true;

	public static GameObject planeStatic;

	public static bool movePlane = false;
	private GameObject[] instantiateWellBig;

	//Camera Stuff
	public static Vector3 CameraOriginalPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
