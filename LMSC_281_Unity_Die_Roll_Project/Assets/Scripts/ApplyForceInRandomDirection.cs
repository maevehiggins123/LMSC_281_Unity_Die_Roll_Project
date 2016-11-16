//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//Allows for autorun functionality
	public bool autoRun = false;



	// Update is called once per frame
	void Update ()
	{

		//roll die with ai
		if (autoRun) {
			
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
		}
	}


}
