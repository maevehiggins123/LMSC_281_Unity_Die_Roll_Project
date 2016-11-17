using UnityEngine;
using System.Collections;

public class SortResults : MonoBehaviour {

	int[] dieResults;
	int one = 0;
	int two = 0;
	int three = 0;
	int four = 0;
	int five = 0;
	int six = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < dieResults.Length; i++) {
			
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
			OnGUI ();
		}
	}

	void OnGUI() {
		
		string numberOne = "1 occurred " + one + " times.";
		string numberTwo = "2 occurred " + two + " times.";
		string numberThree = "3 occurred " + three + " times.";
		string numberFour = "4 occurred " + four + " times.";
		string numberFive = "5 occurred " + five + " times.";
		string numberSix = "6 occurred " + six + " times.";
	}
}
