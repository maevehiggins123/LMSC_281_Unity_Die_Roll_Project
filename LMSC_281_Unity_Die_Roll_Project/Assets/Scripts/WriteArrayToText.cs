//Aaron Spieldenner
//LMSC-281
//Fall 2016
//Die Roll Project
using UnityEngine;
using System.Collections;

//include library for file functions
using System.IO;

public class WriteArrayToText : MonoBehaviour {

	// will be used to identivfy the file we will be writing to  at runtime
	string fileToWriteTo;

	public string stringOfValues;

	public bool runWriteArray = false;

	GameObject playerObject;

	// Use this for initialization
	void Start () {

		//used to write file out to a place where we can find it
		fileToWriteTo = Application.dataPath + "/Resource/Data.txt"; 

		playerObject = GameObject.Find("Die");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (runWriteArray) {
			WriteArray ();
			runWriteArray = false;
		}
	}

	public void WriteArray () {

		for (int i = 0; i<playerObject.GetComponent<DisplayCurrentDieValue> ().allValues.Length; i++) {
			int intArrayValue = playerObject.GetComponent<DisplayCurrentDieValue>().allValues[i];
			stringOfValues = stringOfValues + intArrayValue.ToString ();
		}

		stringOfValues = stringOfValues + "\r\n";
		//Using the append function to write the data out to a text file
		//File.AppendAllText (fileToWriteTo, stringOfValues);

		//overwrite the information in the text file
		File.WriteAllText(fileToWriteTo, stringOfValues);

	}
}
