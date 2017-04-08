//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	//JC we need this value to be public so that we can grab it from another class
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

//		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
//		{
//			rollComplete = true;
//			Debug.Log("Die roll complete, die is at rest");
//		}
//		else if(!GetComponent<Rigidbody>().IsSleeping())
//		{
//			rollComplete = false;
//		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
