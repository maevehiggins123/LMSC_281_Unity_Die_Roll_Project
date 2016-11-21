using UnityEngine;
using System.Collections;

//library to include file operations
using System.IO;

public class ReadDataFromArray : MonoBehaviour {

	string allTextToString;

	// Bool used to trigger the read text function
	public bool readText = false;

	public int[] intArray = new int[100];




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (readText) {
			ReadTextFromFile ();
			readText = false;
		}
	
	}
	public void ReadTextFromFile ()
	{
		//assign all of the text into our string
		allTextToString = File.ReadAllText (Application.dataPath + "/Resources/Data.txt");
		Debug.Log (allTextToString);


		//cycle through  the individual calues in the larger string to get the individual integer values
		for (int i = 0; i < 100; i++)
		{
			//temp veriable to hold individual values as a string
			string tempString = allTextToString[i].ToString();

			intArray [i] = System.Int32.Parse (tempString);
		}
	
	


	}
		}
	
