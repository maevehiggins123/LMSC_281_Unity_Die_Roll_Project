using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDieRoll : MonoBehaviour 
{
	public string buttonName = "Fire1";
	public int numOfRolls = 5;

	int count = 0;

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

		for (int i = 0; i < numOfRolls; i++) 
		{	
			if (canRoll == true) 
			{
				GetComponent<ApplyForce> ().RollDie ();
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
