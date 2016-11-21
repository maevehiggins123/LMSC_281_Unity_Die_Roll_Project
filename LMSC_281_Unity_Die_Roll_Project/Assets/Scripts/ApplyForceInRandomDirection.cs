//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;
	public int rollCount = 0;
	public DisplayCurrentDieValue valueDisplayScript;

	public float numberOneCount = 0;
	public int numberTwoCount = 0;
	public int numberThreeCount = 0;
	public int numberFourCount = 0;
	public int numberFiveCount = 0;
	public int numberSixCount = 0;

	// Update is called once per frame
	void Start ()
	{
		
	}

	void Update ()
	{
		
		
		if (GetComponent<Rigidbody> ().IsSleeping ())
		{
			if (rollCount < 100) {
				GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
				GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
				rollCount = rollCount + 1;
				//Debug.Log (rollCount);
				//Debug.Log ("value is " + valueDisplayScript.currentValue);
				GetComponent<ArrayScript> ().currentNumber = valueDisplayScript.currentValue;
				GetComponent<ArrayScript> ().CaptureToArray ();


				if (GetComponent<ArrayScript> ().currentNumber == 1)
				{
					numberOneCount = numberOneCount + 1;
					Debug.Log ("the number of times 1 has shown is " + numberOneCount);
				}
				if (GetComponent<ArrayScript> ().currentNumber == 2)
				{
					numberTwoCount = numberTwoCount + 1;
					Debug.Log ("the number of times 2 has shown is " + numberTwoCount);
				}
				if (GetComponent<ArrayScript> ().currentNumber == 3)
				{
					numberThreeCount = numberThreeCount + 1;
					Debug.Log ("the number of times 3 has shown is " + numberThreeCount);
				}
				if (GetComponent<ArrayScript> ().currentNumber == 4)
				{
					numberFourCount = numberFourCount + 1;
					Debug.Log ("the number of times 4 has shown is " + numberFourCount);
				}
				if (GetComponent<ArrayScript> ().currentNumber == 5)
				{
					numberFiveCount = numberFiveCount + 1;
					Debug.Log ("the number of times 5 has shown is " + numberFiveCount);
				}
				if (GetComponent<ArrayScript> ().currentNumber == 6)
				{
					numberSixCount = numberSixCount + 1;
					Debug.Log ("the number of times 6 has shown is " + numberSixCount);
				}
			}

		}


	}
	void OnGUI ()
	{
		GUI.Label(new Rect(10, 30, 200, 400), ("The Number of 1's is " + numberOneCount));
		GUI.Label(new Rect(10, 60, 200, 400), ("The Number of 2's is " + numberTwoCount));
		GUI.Label(new Rect(10, 90, 200, 400), ("The Number of 3's is " + numberThreeCount));
		GUI.Label(new Rect(10, 120, 200, 400), ("The Number of 4's is " + numberFourCount));
		GUI.Label(new Rect(10, 150, 200, 400), ("The Number of 5's is " + numberFiveCount));
		GUI.Label(new Rect(10, 180, 200, 400), ("The Number of 6's is " + numberSixCount));

		if (GUI.Button (new Rect (500, 20, 80, 30), "Restart"))
		{
			SceneManager.LoadScene ("DiceRoller3d");
		}
			
	}
}
