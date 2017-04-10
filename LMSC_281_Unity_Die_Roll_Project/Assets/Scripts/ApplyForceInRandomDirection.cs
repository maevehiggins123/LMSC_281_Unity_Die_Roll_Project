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
    public int numberOfRolls = 100; 
	public ForceMode forceMode;

	public int i = 0;

//	bool finalWrite = true;


	//JC while using an instance could work, in this case, it overcomplicates our logic
	//so I've converted this to simply calling the functions and variables as needed
//    void Awake()
//    {
//        instance = this; 
//    }

//    void Start()
//    {
//        //Start Coroutine
//        StartCoroutine(WaitAndPrint());
//    }

	void Start () {
		AddDiceForce();
	}

	void Update () {
		
		if ((i < numberOfRolls) && (GetComponent<DisplayCurrentDieValue>().rollComplete)) {
			AddDiceForce();
			i++;
		}
		else if (i == numberOfRolls && (GetComponent<DisplayCurrentDieValue>().rollComplete)) {
//			GetComponent<WriteResultsToText>().WriteArray();
			i++;
		}
//		else if (finalWrite && (i >= numberOfRolls)) {
//			GetComponent<WriteResultsToText>().WriteArray();
//			finalWrite = false;
//		}
	}
    

	//JC - this was largely duplicating the call to the real process which is the AddDiceForce()
    //Using Enumerator which allows the game to wait before continuing dice rolling loop.
    void WaitAndPrint()
    {
		//JC to match the array position let's start at 0
//        int i = 0;

		//JC this value "21" would be better served as a variable so that if it changes in one script it can change in another
//		while (i < numberOfRolls && !GetComponent<DisplayCurrentDieValue>().rollComplete)
//        {
 //           AddDiceForce();

			//JC we can move the increment to make your debug match human counting expectations
 //           Debug.Log("current roll is:" + i);

            //Wait until roll is complete
            //yield return new WaitUntil(() => DisplayCurrentDieValue.instance.rollComplete); 

//			yield return new WaitUntil(() => (GetComponent<DisplayCurrentDieValue>().rollComplete));
//			i++;

  //      }               
    }


    public void AddDiceForce()
    {
        GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
        GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
    }
}
