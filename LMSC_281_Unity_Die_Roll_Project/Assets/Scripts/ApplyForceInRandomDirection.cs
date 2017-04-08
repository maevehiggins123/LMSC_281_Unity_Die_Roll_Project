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
	public int numOfRolls = 0;
	int totalRolls = 20;

	// Update is called once per frame
	void Update ()
	{
	//	if(Input.GetButtonDown(buttonName))
		if (Input.GetButtonDown (buttonName)) 
		
		{
			//JC the 20 second delay seems a bit excessive so I reduced it to 3
			//We also need a way to stop the invoke, we can add a counter to know when we are done
			InvokeRepeating ("RollSim", 0, 2);
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
			if (rollComplete)
			{
				GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
				GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
				numOfRolls++;
			}
		}
		else {
			//JC we are finished rolling our die, so we can cancel the invoke method call
			CancelInvoke();
		}
	}
}
