//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//JC adding a boolean to be able to control when the die is rolled
	//want the die to roll when the application opens
	public bool rollTheDie = true;

	// Update is called once per frame
	void Update ()
	{
	//	if(Input.GetButtonDown(buttonName))
		if(rollTheDie)
		{
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
			rollTheDie = false;
		}
	}
}
