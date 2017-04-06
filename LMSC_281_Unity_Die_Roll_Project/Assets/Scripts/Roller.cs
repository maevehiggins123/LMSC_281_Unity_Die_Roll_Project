//Trevor Mooney
//3-30-17
//LMSC-281-001
//This is a die rolling simulator that will randomly move the die, then collect the results of the rolls.
//After the selected amount of trials complete, it will print each result to the Debug Log.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Roller : MonoBehaviour {

	//most of the variables are contained here.

	private Rigidbody rb;

	Vector3 launchRot;
	Vector3 launchVel;

	int i = 0;

	float xRot;
	float yRot;
	float zRot;
	float xVel;
	float yVel;
	float zVel;

	public int trials = 10;
	public int[] results = new int[50];
	//public string[] rs = new string[50]; 
	public Text resultsText;
	public Text replayText;
	//public string resultsString = string.Join("",results.Select(i => i.ToString()).ToArray()); 

	bool dropped = true; //I use this to determine when the die is resting, and on the ground after a roll.
	//JC for testing only
	//public bool ng = false;

	public void Start () {

		rb = GetComponent<Rigidbody> ();

		resultsText.text = "";
		replayText.text = "";


	}

	//This will keep rolling the die until it reaches the set amount of trials.
	public void Update(){
		if (i < trials) {
			Controller ();
		}

		//JC moved this so the load game will work, and no need for the invoke
//		if (ng == true) {
//			Debug.Log ("gogogo");
//	//		Invoke ("NewGame", 2);
//			NewGame();
//			ng = false;
//		}

		//JC rewriting just to use a keyboard input rather than the Boolean value
		if (Input.GetKeyDown("space")) {
			NewGame();
		}
	}
		
	//This is where the magic happens...
	//It contains 2 main if-statements that will alternate depending on the state of the die.
	public void Controller(){

		//These variables are used to hold which face of the die is face-up.
		float sideOne = Vector3.Dot(transform.up, Vector3.up);
		float sideFive = Vector3.Dot(transform.right, Vector3.up);
		float sideThree = Vector3.Dot(transform.forward, Vector3.up);
		float sideSix = Vector3.Dot(-transform.up, Vector3.up);
		float sideFour = Vector3.Dot(-transform.right, Vector3.up);
		float sideTwo = Vector3.Dot(-transform.forward, Vector3.up);

		//The first of the if-statements.  This one is "launch", it holds all of the phyisics calculations on the die.
		//It randomly generates a velocity and rotation vector to act on the die.
		//It also sets the dropped to false to activate the second if-statement.
		if (rb.IsSleeping () && dropped == true) {

			//Debug.Log ("launch");

			xRot = Random.Range (0f, 3.6f);
			yRot = Random.Range (0f, 3.6f);
			zRot = Random.Range (0f, 3.6f);

			xVel = Random.Range (-8f, 8f);
			yVel = Random.Range (8f, 10f);
			zVel = Random.Range (-8f, 8f);

			launchRot = new Vector3 (xRot, yRot, zRot);
			launchVel = new Vector3 (xVel, yVel, zVel);

			rb.AddForce (launchVel, ForceMode.Impulse);
			rb.AddTorque(launchRot * 100);
	
			dropped = false;

		}


		//The second if-statement named "think".  This determines which side is up, stores the number from the die into 
		//the array, then it will increment the array position.
		if (rb.IsSleeping () && dropped == false) {

			//Debug.Log("think");
		 
			if ((Mathf.Round (sideOne)) == 1) {
				//Debug.Log ("1");
				results [i] = 1;
				i++;
			} else if ((Mathf.Round (sideTwo)) == 1) {
				//Debug.Log ("2");
				results [i] = 2;
				i++;
			} else if ((Mathf.Round (sideThree)) == 1) {
				//Debug.Log ("3");
				results [i] = 3;
				i++;
			} else if ((Mathf.Round (sideFour)) == 1) {
				//Debug.Log ("4");
				results [i] = 4;
				i++;
			} else if ((Mathf.Round (sideFive)) == 1) {
				//Debug.Log ("5");
				results [i] = 5;
				i++;
			} else if ((Mathf.Round (sideSix)) == 1) {
				//Debug.Log ("6");
				results [i] = 6;
				i++;
			} else {
				results [i] = -1;
				//this was used to find errors
				//Debug.Log ("-1");
				i++;
			}


			//This will occur once the amount of trials is completed, then it will print each result into it's own line.
			if (i == trials) {

				//JC you had the following line commented out but it works fine
				replayText.text = "Press Space To Play Again";
				for (int j = 0; j < trials; j++) 
				{
					//JC we need to add the integer we are using "j" to the passed parameter
					//SetResultsText (j);
					//JC or you can do it this way
					resultsText.text = resultsText.text + "It rolled " + results[j].ToString() + " on roll " + (j+1) + "." + "\n";
					Debug.Log("It rolled " + results[j].ToString() + " on roll " + (j+1) + ".");

				}

				//Debug.Log ("done");
				//ng = true;
				//Debug.Log ("true");

				}

			dropped = true; // this will send the die back to the "launch" if-statement.
		}
	}

	void SetResultsText (int j){	
		resultsText.text = "It rolled " + results[j].ToString() + " on roll " + (j+1) + ".";
		//Debug.Log("It rolled " + results[j].ToString() + " on roll " + (j+1) + ".");
	}

	public void NewGame(){

		SceneManager.LoadScene("Main");

	}
}
