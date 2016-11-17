//Aaron Spieldenner
//LMSC-281
//Fall 2016
//Die Roll Project
//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//to allow for autorun functionality
	public bool autoRun = false;

	// Update is called once per frame
	void Update ()
	{
		if (autoRun) { //this is determined by the DisplayCurrentDieValue script
			//move player with ai
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
		}
	}
}
