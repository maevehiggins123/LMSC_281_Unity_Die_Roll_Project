using UnityEngine;
using System.Collections;

public class ArrayScript : MonoBehaviour {

	public DisplayCurrentDieValue valueDisplayScript;
	//array to hold all the values
	public int[] allScores = new int[100];
	public int arrayPosition = 0;
	//holds the value recieved for the game
	public int currentNumber = 1;



	// Use this for initialization
	void Start () {
	//	CaptureToArray ();
	}
	
	// Update is called once per frame
	void Update () {
		currentNumber = valueDisplayScript.currentValue;
	
	}
	public void CaptureToArray ()
	{
		//check to ensure the array position is valid
		if (arrayPosition < allScores.Length) {
			allScores [arrayPosition] = currentNumber;
			//Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allScores [arrayPosition]);
			arrayPosition++;	
		}
	}
}
