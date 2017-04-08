using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ArrayToText : MonoBehaviour {

	string fileToWriteTo;

	public string stringOfResults;

	public bool runWriteArray = false;

	GameObject die;

	void Start () {


		fileToWriteTo = Application.dataPath + "/Resources/Results.txt";

		die = GameObject.Find ("Die");
	}

	void Update(){
//		if (runWriteArray) {
//			WriteArray ();
//			runWriteArray = false;
//		}
	}

	public void WriteArray (){

		for (int i = 0; i < die.GetComponent<DisplayCurrentDieValue> ().results.Length; i++) {
			int intArrayValue = die.GetComponent<DisplayCurrentDieValue> ().results [i];
			stringOfResults = stringOfResults + intArrayValue.ToString ();
		}

		stringOfResults = stringOfResults + "\r\n";

		File.AppendAllText (fileToWriteTo, stringOfResults);

		//to overwrite
//		File.WriteAllText (fileToWriteTo, stringOfResults);
	}
}
