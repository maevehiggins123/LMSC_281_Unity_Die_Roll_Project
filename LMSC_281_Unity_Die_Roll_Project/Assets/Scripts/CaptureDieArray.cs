using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureDieArray : MonoBehaviour {
	//JC I made the array public so I could see the values in the inspector
	public int [] allScores;// = new int [100];

	//JC in order to be able to adjust the number of rolls for testing
	public int numOfRolls = 2;

	public int arrayPosition = 0;

	//JC adding the ability to automate any number of rolls
	void Start () {
		allScores = new int[numOfRolls];
	}

	public void CaptureToArray(){

		//JC you've got a partial for loop syntax as well as an if decision statement
		//so I cleaned it up to just be an if statement
		if (arrayPosition < allScores.Length) {
//			arrayPosition = currentNumber;
			allScores[arrayPosition] = GetComponent<DisplayCurrentDieValue>().currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allScores [arrayPosition]);
			arrayPosition++;
		}
	}
			
			


		// Use this for initialization
		//void Start () { 
		//CaptureToArray();;
		//;
}