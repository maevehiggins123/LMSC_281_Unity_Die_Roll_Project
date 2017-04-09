//example provided by http://www.cookingwithunity.com/
//Prin Keerasuntonpong
//4/01/17
//LMSC-281 Roll the Die Simulation Assignment
using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
    public static ApplyForceInRandomDirection instance; 

	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
    public int numberOfRolls; 
	public ForceMode forceMode;

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        //Start Coroutine
        StartCoroutine(WaitAndPrint());
    }
    
    //Using Enumerator which allows the game to wait a number of seconds before continuing dice rolling loop.
    IEnumerator WaitAndPrint()
    {
		//JC to match the array position let's start ay 0
        int i = 0;

		//JC this value "21" would be better served as a variable so that if it changes in one script it can change in another
        while (i < numberOfRolls)
        {
            AddDiceForce();

			//JC we can move the increment to make your debug match human counting expectations
			i++;
            Debug.Log("current roll is:" + i);

            //Wait until roll is complete
            yield return new WaitUntil(() => DisplayCurrentDieValue.instance.rollComplete); 
          

        }               
    }

    void AddDiceForce()
    {
        GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
        GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
    }
}
