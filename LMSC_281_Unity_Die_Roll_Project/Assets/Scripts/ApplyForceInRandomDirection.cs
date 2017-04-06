//LMSC 281 
//Augustus Rivera
//Roll a Die

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//JC creating a boolean value to control the die rolling automatically
	public bool rollAgain = true;	//this is public so that another class can adjust it

	// Update is called once per frame
	void Update ()
	{
	//	if(Input.GetButtonDown(buttonName))

		//JC rather than using the button input, we will automatically roll the die
		if(rollAgain)
		{
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
		}
	}
}
