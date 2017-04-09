//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	public bool lifeTimeToggle = false;

	public int trials = 100;
	public int[] results = new int[100];
	public int i = 0;

	float numOfOne = 0;
	float numOfTwo = 0;
	float numOfThree = 0;
	float numOfFour = 0;
	float numOfFive = 0;
	float numOfSix = 0;

	private bool rollComplete = false;



	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if (i < trials) {
			Automator ();
		}

		if (i == trials) {
			GetComponent<ArrayToText> ().WriteArray ();
			GetComponent<ReadArrayFromText> ().ReadTextFromFile();

			NumGatherer ();


			i++;
		}
	}

	void Automator(){
		
		if(GetComponent<Rigidbody>().IsSleeping() && rollComplete == false){
				
			//Debug.Log("Die roll complete, die is at rest");
			GetComponent<ApplyForceInRandomDirection>().Roller();
			rollComplete = true;
		}
		if (GetComponent<Rigidbody> ().IsSleeping () && rollComplete == true) {
			results [i] = currentValue;
			rollComplete = false;
			i++;
		}
	}

	//everything is in place, need to add real time results, then display total results if toggled.

	void OnGUI()
	{

			GUI.Box (new Rect (10, 10, 100, 180), "Results");

			GUI.Label (new Rect (20, 30, 100, 30), "1: " + numOfOne + "     %" + numOfOne / 100);
			GUI.Label (new Rect (20, 50, 100, 30), "2: " + numOfTwo + "     %" + numOfTwo / 100);
			GUI.Label (new Rect (20, 70, 100, 30), "3: " + numOfThree + "     %" + numOfThree / 100);
			GUI.Label (new Rect (20, 90, 100, 30), "4: " + numOfFour + "     %" + numOfFour / 100);
			GUI.Label (new Rect (20, 110, 100, 30), "5: " + numOfFive + "     %" + numOfFive / 100);
			GUI.Label (new Rect (20, 130, 100, 30), "6: " + numOfSix + "     %" + numOfSix / 100);


		if(GUI.Button(new Rect(20,160,80,20), "Play Again")){
			Invoke("DisplayCurrentDieValue", 3);
		}
	}

	void NumGatherer(){

		for (int a = 0; a < results.Length; a++) {
			if (results [a] == 1) {
				numOfOne++;
			} else if (results [a] == 2) {
				numOfTwo++;
			} else if (results [a] == 3) {
				numOfThree++;
			} else if (results [a] == 4) {
				numOfFour++;
			} else if (results [a] == 5) {
				numOfFive++;
			} else if (results [a] == 6) {
				numOfSix++;
			}
		}

		//Debug.Log (numOfOne + " " + numOfTwo + " " + numOfThree + " " + numOfFour + " " + numOfFive + " " + numOfSix);

	}

}
