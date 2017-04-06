//example provided by http://www.cookingwithunity.com/
//Prin Keerasuntonpong
//4/01/17
//LMSC-281 Roll the Die Simulation Assignment
using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;


    void Start()
    {
        //Start Coroutine
        StartCoroutine(WaitAndPrint());      
    }
    
    //Using Enumerator which allows the game to wait a number of seconds before continuing dice rolling loop.
    IEnumerator WaitAndPrint()
    {
        int i = 1;
        while (i < 21)
        {
            AddDiceForce();
            Debug.Log("current roll is:" + i);
            yield return new WaitForSeconds(6f);
          
            i++;
        }               
    }

    void AddDiceForce()
    {
        GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
        GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
    }
}
