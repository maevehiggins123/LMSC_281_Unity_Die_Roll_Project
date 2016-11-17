//Aaron Spieldenner
//LMSC-281
//Fall 2016
//Die Roll Project
//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	private bool rollComplete = false;

	//array to hold die values
	public int[] allValues = new int[5];

	public int arrayPosition = 0;

	//used to access the TextHelper
	GameObject textWriter;

	//taken from ApplyForceInRandomDirection
	//public float forceAmount = 10.0f;
	//public float torqueAmount = 10.0f;
	//public ForceMode forceMode;

	// Update is called once per frame

	void Start () {
		//Every time I refer to textWriter, I'm referring to this object.
		textWriter = GameObject.Find ("Text Helper"); //this was Conrad's idea
	}

	void Update ()
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) {
			currentValue = hit.collider.GetComponent<DieValue> ().value;
		}

		if (GetComponent<Rigidbody> ().IsSleeping () && !rollComplete) {
			rollComplete = true;
			GetComponent<ApplyForceInRandomDirection> ().autoRun = true; //This accesses the autoRun variable in the ApplyFoceInRandomDirection script.  It turns it true, which then runs the autoRun if statement in that script.
			CaptureToArray ();
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false; //Same as above, but false. 
		}
			
	}

	public void CaptureToArray () {
		if (arrayPosition < allValues.Length) {
			allValues [arrayPosition] = currentValue;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allValues [arrayPosition]);
			arrayPosition++;
		}

		if (arrayPosition == allValues.Length) {
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;
			//turns runWriterArray and readText on without having to do so in the inspector
			textWriter.GetComponent<WriteArrayToText> ().runWriteArray = true;
			textWriter.GetComponent<ReadArrayFromText> ().readText = true;

		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}


}
