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
	public int[] allValues = new int[5];

	//set initial array position
	public int arrayPosition = 0;

	//Needed for access to TextHelper object, for turning "runWriteArray" to true
	GameObject TextWriter;

	void Start () {

		//finding TextHelper object
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

			//if die is done rolling, apply the autoRun force to automatically roll die again
			GetComponent<ApplyForceInRandomDirection> ().autoRun = true;
			CaptureToArray();

		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;

			//if die is not done rolling, do not apply the autoRun force
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;
		}

	}

	public void CaptureToArray () {


		if (arrayPosition < allValues.Length) {
			allValues [arrayPosition] = currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allValues [arrayPosition]);
			arrayPosition++;
		}

		if (arrayPosition == allValues.Length) {
			//turn off the auto rolling capabilities
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;

			//run our write array function
			TextWriter.GetComponent<WriteToText> ().runWriteArray = true;

			//run our read text function
			TextWriter.GetComponent<ReadArrayFromText> ().readText = true;
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
