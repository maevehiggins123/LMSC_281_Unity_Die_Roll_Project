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

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
