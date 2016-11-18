//Conrad Robertson
//LMSC-281
//Fall 2016
//Die Roll Project

//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	private bool rollComplete = false;

	//array to hold the die values
	public int[] allValues = new int[100];

	//set initial array position
	public int arrayPosition = 0;

	//Needed for access to TextHelper object, for turning "runWriteArray" to true
	GameObject TextWriter;

//	//Variables to count how many times a particular number appears
	public int OneCount = 0;
	public int TwoCount = 0;
	public int ThreeCount = 0;
	public int FourCount = 0;
	public int FiveCount = 0;
	public int SixCount = 0;


	void Start () {

		//finding TextHelper game object so we can write and read text
		TextWriter = GameObject.Find("TextHelper");
	}

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;

			//if die is done rolling, apply the autoRun force to automatically roll die again (true)
			GetComponent<ApplyForceInRandomDirection> ().autoRun = true;
			CaptureToArray();

		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;

			//if die is not done rolling, do not apply the autoRun force (false)
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;
		}

	}

	public void CaptureToArray () {

		//if array is NOT full, put current die value into current array position, then move to the next array position
		if (arrayPosition < allValues.Length) {
			allValues [arrayPosition] = currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allValues [arrayPosition]);
			arrayPosition++;

			//for (int i = 0; i < allValues.Length; i++) {
							switch(currentValue) {
				
							case 1:
								OneCount++;
								break;
							case 2:
								TwoCount++;
								break;
							case 3:
								ThreeCount++;
								break;
							case 4:
								FourCount ++;
								break;
							case 5:
								FiveCount++;
								break;
							case 6:
								SixCount++;
								break;
							}
						}
			



		//if array is full
		if (arrayPosition == allValues.Length) {
			
			//turn off the auto rolling capabilities
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;

			//run our write array function
			TextWriter.GetComponent<WriteToText> ().runWriteArray = true;

			//run our read text function
			TextWriter.GetComponent<ReadArrayFromText> ().readText = true;

			NumberCount ();
		}
	}

	void NumberCount () {

		//Testing that numbers are totaling correctly
		Debug.Log ("Four count is " + FourCount);

	}

	void OnGUI (){

		//Display number of times a number was rolled compared to expected amount
		GUILayout.Label("The number 1 was rolled " + OneCount + " times out of expected 16.6");
		GUILayout.Label("The number 2 was rolled " + TwoCount + " times out of expected 16.6");
		GUILayout.Label("The number 3 was rolled " + ThreeCount + " times out of expected 16.6");
		GUILayout.Label("The number 4 was rolled " + FourCount + " times out of expected 16.6");
		GUILayout.Label("The number 5 was rolled " + FiveCount + " times out of expected 16.6");
		GUILayout.Label("The number 6 was rolled " + SixCount + " times out of expected 16.6");
	}


	}