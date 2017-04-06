//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour {

	//JC since this variable name exists in two places we need to only use one
	//public int DieRoll = 20;
	public GameObject restartButton;

	//JC no longer needed as we have auto roll
//	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//JC no longer need as we have the various scripts sitting on the same object
//	public GameObject Die;

	public bool readyToThrow = true;

	void Start ()
	{
		//JC these aren't necessary since we will be using a Boolean to control when the die is rolled
//		InvokeRepeating ("Throw", 2, 3);
//
//		while (DieRoll > 0) 
//		{
//			Invoke ("Thorw", 2);
//			DieRoll--;
//		}
	}

	//JC need to make this public so we can call it from another Class
	public void Throw()
	{
	//	if (DieRoll > 0)
		{
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
//			DieRoll--;
			readyToThrow = false;
			//JC we will need to turn this back to true when the die comes to rest
		}
	}


	// Update is called once per frame
	void Update ()
	{
		//JC removed this as it is now rolling automatically
//		if (Input.GetButtonDown (buttonName)) 
//		{
//			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
//			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
//		}

		//JC this section is duplicated in the gamecontroller class
//		if (DieRoll <= 0) 
//		{
//			GameOver ();
//		} 
//		else if (readyToThrow) 
//		{
//			Throw ();
//		}
	}

	//JC this is duplicated from your GameController Class
//	void GameOver ()
//	{
//		restartButton.SetActive (true);
//	}
//
//	public void RestartGame ()
//	{
//		restartButton.SetActive (false);
//	}
}
