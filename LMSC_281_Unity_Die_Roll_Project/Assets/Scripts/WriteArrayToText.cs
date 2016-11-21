using UnityEngine;
using System.Collections;

//include library for file functions
using System.IO;

public class WriteArrayToText : MonoBehaviour {

	string fileToWriteTo;

	public string stringOfValues;

	public bool runWriteArray = false;

	GameObject playerObject;

	// Use this for initialization
	void Start () {



		//to write a file to a file called Resources
		fileToWriteTo = Application.dataPath + "/Resources/Data.txt";

		playerObject = GameObject.Find ("Die");
	
	}

	// Update is called once per frame
	void Update () {
		if (runWriteArray) 
		{
			WriteArray ();
			runWriteArray = false;
		}
	
	}

	public void WriteArray () {
		for (int i = 0; i < playerObject.GetComponent<ArrayScript>().allScores.Length; i++) {
			int intArrayValue = playerObject.GetComponent<ArrayScript> ().allScores[i];
			stringOfValues = stringOfValues + intArrayValue.ToString ();
		}
		//Using the append function to write the data out to 
		File.AppendAllText (fileToWriteTo, stringOfValues);
	}
}
