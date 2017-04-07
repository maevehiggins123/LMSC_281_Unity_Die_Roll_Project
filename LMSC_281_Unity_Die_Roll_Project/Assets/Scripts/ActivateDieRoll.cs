using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDieRoll : MonoBehaviour 
{
	public string buttonName = "Fire1";
	public int numOfRolls = 20;

	public int count = 0;

	bool canRoll = false;

	void Update()
	{
		if (GetComponent<DisplayCurrentDieValue>().rollComplete == true)
		{
			canRoll = true;
		}
		else
		{
			canRoll = false;
		}

		//JC as we discussed, this "i" value is resetting itself after every cycle of the Update() function
		//we need to create a variable that will persist and then if we swap the conditional if to a two decision 
		//statement we can control the roll in a more predictable way
//		for (int i = 0; i < numOfRolls; i++) 

		if (canRoll == true && count < numOfRolls) 
		{
			GetComponent<ApplyForce> ().RollDie ();
			//JC we need to increment our count after we roll
			count++;
			//JC when we are done, we write the values to the text field
			if (count == numOfRolls) {
				GetComponent<CaptureValue>().DisplayArrayValues();
			}
		}
	}
		// WORKS WORKS WORKS WORKS.... when in update
//		if (GetComponent<DisplayCurrentDieValue>().rollComplete == true) 
//		{
//			GetComponent<ApplyForce> ().RollDie ();
//		}
//	}	
}
