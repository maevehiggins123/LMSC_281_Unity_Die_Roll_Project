using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ReadArrayFromText : MonoBehaviour {

	string allTextString;
	public bool readText = false;

	public int[] intArray = new int[100];

	void Start () {
		
	}
	

	void Update () {
//		if (readText) {
//			ReadTextFromFile ();
//			readText = false;
//		}
	}

	public void ReadTextFromFile(){
		allTextString = File.ReadAllText (Application.dataPath + "/Resources/Results.txt");
		Debug.Log (allTextString);

		for (int i = 0; i < 100; i++) {
			string tempString = allTextString [i].ToString ();
			//Debug.Log (tempString);

			intArray [i] = System.Int32.Parse(tempString);

		}
	}
}
