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

	// Update is called once per frame
	void Update ()
	{
	//	if(Input.GetButtonDown(buttonName))
		if (Input.GetButtonDown (buttonName)) 
		
		{
			InvokeRepeating ("RollSim", 0, 20);
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
		if (rollComplete = true)
		{
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
		}
	}
}
