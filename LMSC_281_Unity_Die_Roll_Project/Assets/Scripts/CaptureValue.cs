//LMSC-281
//Kenny Harmon
//Die Roll Project
//Store die value to array

using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CaptureValue : MonoBehaviour {

	//array for storing die values
	int[] storeDieValue = new int[20];
	int arrayPosition = 0;

	public Text rollLog;

	public void CaptureToArray()
	{
		//checking array position validity
		if (arrayPosition < storeDieValue.Length) 
		{
			//pull current die value from the display script
			storeDieValue [arrayPosition] = GetComponent<DisplayCurrentDieValue>().currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + storeDieValue [arrayPosition]);
			arrayPosition++;
		}
	}
}
