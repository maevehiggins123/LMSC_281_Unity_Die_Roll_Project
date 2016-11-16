//Conrad Robertson
//LMSC-281
//Fall 2016
//Die Roll Project

using UnityEngine;
using System.Collections;

using System.IO;

public class WriteToText : MonoBehaviour {


	string FileToWriteTo;

	public string StringOfValues;

	public bool runWriteArray = false;

	//Will become our die
	GameObject playerObject;


	// Use this for initialization
	void Start () {

		//creating file path to save text file
		FileToWriteTo = Application.dataPath + "/Resources/Data.txt";

		//to find current value
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

		//write to text our array values in order of occurance; unfilled spots will return a value of "0"
		for (int i = 0; i < playerObject.GetComponent<DisplayCurrentDieValue> ().allValues.Length; i++) {
			int intArrayValue = playerObject.GetComponent<DisplayCurrentDieValue> ().allValues [i];
			StringOfValues = StringOfValues + intArrayValue.ToString ();

		}

		StringOfValues = StringOfValues + "\r\n";

			//File.AppendAllText (FileToWriteTo, StringOfValues);

		//overwrite information in the text file
		File.WriteAllText (FileToWriteTo, StringOfValues);
	}
}
