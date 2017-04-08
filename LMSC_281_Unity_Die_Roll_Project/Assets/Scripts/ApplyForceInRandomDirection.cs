//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	private bool rollComplete = false;

	//JC so we can track the number of rolls and also know the position in the array we need a counter and a total
	public int numOfRolls = -1;
	int totalRolls = 20;

	//JC we need an array to hold the values of our rolls
	public int[] allRolls;

	//JC so that our array can use the above variable "totalRolls" as its size we need to initialize it in the Start function
	void Start () {
		allRolls = new int[totalRolls];
	}

	// Update is called once per frame
	void Update ()
	{
	//	if(Input.GetButtonDown(buttonName))
		if (Input.GetButtonDown (buttonName)) 
		
		{
			//JC the 20 second delay seems a bit excessive so I reduced it to 1
			//We also need a way to stop the invoke, we can add a counter to know when we are done
			InvokeRepeating ("RollSim", 0, 1);
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}
	}

	void RollSim()
	{
		//JC we need a counter to know whether we should roll again or not
		if (numOfRolls < totalRolls) {
			if (rollComplete) {
				//JC now that we know a roll has been completed, we can capture the value just prior to rolling again
				//but we don't want the initial value when the application first opens
				if (numOfRolls >= 0) {
					CaptureToArray();
				}
				GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
				GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
				numOfRolls++;
			}
		}
		else {
			//JC we are finished rolling our die, so we can cancel the invoke method call
			//but first we need to capture the last roll
			CaptureToArray();
			CancelInvoke();
		}
	}

	//JC so that we can create a separate function to capture our values
	void CaptureToArray () {
		if (numOfRolls < allRolls.Length) {
			allRolls[numOfRolls] = GetComponent<DisplayCurrentDieValue>().currentValue;
		}
	}
}
