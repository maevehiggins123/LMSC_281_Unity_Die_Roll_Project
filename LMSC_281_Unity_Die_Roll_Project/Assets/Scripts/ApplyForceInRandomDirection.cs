//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour {

	public int DieRoll = 20;
	public GameObject restartButton;

	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	public GameObject Die;

	public bool readyToThrow = true;

	void Start ()
	{
		InvokeRepeating ("Throw", 2, 3);

		while (DieRoll > 0) 
		{
			Invoke ("Thorw", 2);
			DieRoll--;
		}
	}
		
	void Throw()
	{
		if (DieRoll > 0)
		{
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
			DieRoll--;
			readyToThrow = false;
		}
	}


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (buttonName)) 
		{
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
		}

		if (DieRoll <= 0) 
		{
			GameOver ();
		} 
		else if (readyToThrow) 
		{
			Throw ();
		}
	}

	void GameOver ()
	{
		restartButton.SetActive (true);
	}

	public void RestartGame ()
	{
		restartButton.SetActive (false);
	}
}
