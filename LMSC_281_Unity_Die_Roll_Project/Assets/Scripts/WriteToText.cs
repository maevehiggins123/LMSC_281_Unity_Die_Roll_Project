using UnityEngine;
using System.Collections;

using System.IO;

public class WriteToText : MonoBehaviour {


	string FileToWriteTo;

	public string StringOfValues;

	public bool runWriteArray = false;

	GameObject playerObject;


	// Use this for initialization
	void Start () {

		FileToWriteTo = Application.dataPath + "/Resources/Data.txt";

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
