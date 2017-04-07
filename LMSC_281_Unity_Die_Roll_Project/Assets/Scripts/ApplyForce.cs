//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour
{
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	public void RollDie ()
	{
		GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
		GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
	}
}
