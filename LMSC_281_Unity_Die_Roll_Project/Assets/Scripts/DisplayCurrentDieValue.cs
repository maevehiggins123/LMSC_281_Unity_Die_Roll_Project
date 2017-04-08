//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	public int trials = 100;
	public int[] results = new int[100];
	public int i = 0;

	private bool rollComplete = false;



	// Update is called once per frame
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
			//GetComponent<ArrayToText> ().runWriteArray = true;
			GetComponent<ArrayToText> ().WriteArray ();
			//GetComponent<ArrayToText> ().runWriteArray = false;
			//GetComponent<ReadArrayFromText> ().readText = true;
			GetComponent<ReadArrayFromText> ().ReadTextFromFile();
			//GetComponent<ReadArrayFromText> ().readText = false;
			i++;
		}
		if (i == trials + 1) {

		}
	}

	void Automator(){
		
		if(GetComponent<Rigidbody>().IsSleeping() && rollComplete == false){
				
			Debug.Log("Die roll complete, die is at rest");
			GetComponent<ApplyForceInRandomDirection>().Roller();
			rollComplete = true;
		}
		if (GetComponent<Rigidbody> ().IsSleeping () && rollComplete == true) {
			results [i] = currentValue;
			Debug.Log (i + "f");
			rollComplete = false;
			i++;
		}
	}

	//everything is in place, need to add real time results, then display total results if toggled.

	void OnGUI()
	{
		bool lifeTimeToggle = false;

		GUI.Box (new Rect (10, 10, 120, 230), "Results");

		GUI.Label (new Rect (20, 30, 100, 30), "1: ");
		GUI.Label (new Rect (20, 50, 100, 30), "2: ");
		GUI.Label (new Rect (20, 70, 100, 30), "3: ");
		GUI.Label (new Rect (20, 90, 100, 30), "4: ");
		GUI.Label (new Rect (20, 110, 100, 30), "5: ");
		GUI.Label (new Rect (20, 130, 100, 30), "6: ");

		if(GUI.Toggle (new Rect (20,180,100,30), lifeTimeToggle, " Total Results")){

		}

		if(GUI.Button(new Rect(30,210,80,20), "Play Again")){
			//Invoke(Automator(), 3);
		}
	}

}
