using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureDieArray : MonoBehaviour {
	int [] allScores = new int [100]; 

	int arrayPosition = 0;
	public int CurrentNumber = 1;

	public void CaptureToArray(){
		if (arrayPosition<allScores.Length> [arrayPosition] = CurrentNumber)
			Debug.Log ("The current array position is" + arrayPosition + "with a value of" + allScores [arrayPosition]);
		arrayPosition++
			
			


		// Use this for initialization
		//void Start () { 
		//CaptureToArray();;
		;
}

}