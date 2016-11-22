using UnityEngine;
using System.Collections;

public class SortResults : MonoBehaviour {

	//JC - we need to find a way to access the original set of values, 
	//we could do that by reading in the data from the text file, 
	//or we could access them in the original script
	public GameObject target;

	int[] dieResults;
	int one = 0;
	int two = 0;
	int three = 0;
	int four = 0;
	int five = 0;
	int six = 0;

	public bool readyToSort = true;


	// Use this for initialization
	void Start () {
		//JC - assign the original array to the array being used in this class
		dieResults = target.GetComponent<DisplayCurrentDieValue> ().allValues;
	}
	
	// Update is called once per frame
	void Update () {

		//JC - since this is sitting in the update Method, we need to make sure it only runs once
		//we can do this with a boolean value
		if (readyToSort) {

			for (int i = 0; i < dieResults.Length; i++) {
				//JC we could also just access the riginal array as well by using the following
				//this would require us to replace dieResults in the if logic below
				//	for (int i = 0; i < target.GetComponent<DisplayCurrentDieValue>().allValues.Length; i++) {
						
				if (dieResults [i] == 1) {
					one++;
				} else if (dieResults [i] == 2) {
					two++;
				} else if (dieResults [i] == 3) {
					three++;
				} else if (dieResults [i] == 4) {
					four++;
				} else if (dieResults [i] == 5) {
					five++;
				} else if (dieResults [i] == 6) {
					six++;
				} else {
					Debug.Log ("Invalid Number");
				}
			}
			//JC - once we've processed the array once, we don't need to continue processing
			//so we set the boolean back to false
			readyToSort = false;
			//JC- the OnGUI Method just runs automatically... like Update, so no need ot call it, 
			//but then we do need to control when it would show the items, probably with a boolean value
		//	OnGUI ();
		}
	}

	void OnGUI() {
		
		string numberOne = "1 occurred " + one + " times.";
		string numberTwo = "2 occurred " + two + " times.";
		string numberThree = "3 occurred " + three + " times.";
		string numberFour = "4 occurred " + four + " times.";
		string numberFive = "5 occurred " + five + " times.";
		string numberSix = "6 occurred " + six + " times.";

		//JC - we could do this more elegantly, similarly to one of the MadLibs examples where we set an offset
		GUI.Label (new Rect (10, 10, 200, 20), numberOne);
		GUI.Label (new Rect (10, 40, 200, 20), numberTwo);
		GUI.Label (new Rect (10, 70, 200, 20), numberThree);
		GUI.Label (new Rect (10, 100, 200, 20), numberFour);
		GUI.Label (new Rect (10, 130, 200, 20), numberFive);
		GUI.Label (new Rect (10, 160, 200, 20), numberSix);
	}
}
