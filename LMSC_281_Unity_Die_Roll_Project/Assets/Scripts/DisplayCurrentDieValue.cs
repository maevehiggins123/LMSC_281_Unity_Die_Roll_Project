//LMSC 281 
//Augustus Rivera
//Roll a Die

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	public int currentValue = 1;



	private bool rollComplete = false;

	public int[] dieResults = new int[20];

	private int arrayPosition = 0;

	void Start ()
	{
		//JC we will do this after a roll has been completed
//		CaptureToArray ();
	}

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
			//JC we can capture the values after the roll is complete
			CaptureToArray();
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
			//JC if the die is currently moving we shouldn't be trying to roll it
			GetComponent<ApplyForceInRandomDirection>().rollAgain = false;

		}
	}

	//JC so move that function declaration up here as commented out a few lines below
	public void CaptureToArray ()
	{
		//JC the dieResults is an array so we need to reference a position
//		while (arrayPosition < 20) {
		//JC we can't embed a function inside another function in this way we need it to be topmost as a declared method
//		public void CaptureToArray()
		if (arrayPosition < dieResults.Length) {
			dieResults [arrayPosition] = currentValue;
			//checking our logic
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + dieResults [arrayPosition]);
			//get ready to capture the next number
			arrayPosition++;
			//JC if we need to roll again, we will set the boolean in the ApplyForce class to true 
			GetComponent<ApplyForceInRandomDirection>().rollAgain = true;
		}


//		}
	}
		

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
