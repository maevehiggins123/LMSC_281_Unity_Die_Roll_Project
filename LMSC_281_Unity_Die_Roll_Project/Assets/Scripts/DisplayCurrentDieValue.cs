//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	//JC made this public so the CaptureDieValue could use it
	public int currentValue = 1;

	private bool rollComplete = false;

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
			Debug.Log("Die roll complete, die is at rest");
			//JC adding the capture function here
			GetComponent<CaptureDieArray>().CaptureToArray();

			//JC check to see if we need to do another roll
			if ((GetComponent<CaptureDieArray>().arrayPosition) < (GetComponent<CaptureDieArray>().numOfRolls) ) {
				GetComponent<ApplyForceInRandomDirection>().rollTheDie = true;
			}
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
