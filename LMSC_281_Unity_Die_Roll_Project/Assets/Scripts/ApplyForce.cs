//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour
{
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;


	//JC this will be useful, as you've shown it can now simply be called as a function when we need it to run
	public void RollDie ()
	{
		GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
		GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
	}
}
