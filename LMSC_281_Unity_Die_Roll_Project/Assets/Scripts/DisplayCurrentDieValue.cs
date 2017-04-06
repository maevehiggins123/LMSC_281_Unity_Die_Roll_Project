//LMSC 281 
//Augustus Rivera
//Roll a Die

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	public int currentValue = 1;



	private bool rollComplete = false;

	public int[] dieResults = new int[20];

	private int arrayPosition = 0;
	// Update is called once per frame

	void Start ()
	{
		CaptureToArray ();
	}

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
			Debug.Log("Die roll complete, die is at rest");
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}
	}
	while (dieResults < 20) {
		public void CaptureToArray()
		{
		
			if (arrayPosition < dieResults.Length) {
				dieResults [arrayPosition] = currentValue;
				//checking our logic
				Debug.Log ("The current array position is " + arrayPosition + " with a value of " + dieResults [arrayPosition]);
				//get ready to capture the next number
				arrayPosition++;
			}
		}
	}
		

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
