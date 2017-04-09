//example provided by http://www.cookingwithunity.com/
//Prin Keerasuntonpong
//4/01/17
//LMSC-281 Roll the Die Simulation Assignment
using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;
	public int currentValue = 1;
	public bool rollComplete = false;

    public static DisplayCurrentDieValue instance;

	//Grabing number of rolls from the public variable
    public int[] dieNumberArray = new int[ApplyForceInRandomDirection.instance.numberOfRolls];

	//JC begin your counter at 0, to match the way an array position begins
    int rollCounter = 0;

    void Awake()
    {
        instance = this;
    }

    void Update ()
	{
        //call DiceRoll method
        DiceRoll();
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}


    void DiceRoll()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer))
        {
            currentValue = hit.collider.GetComponent<DieValue>().value;
        }

        if (GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
        {
            rollComplete = true;
            Debug.Log("Die roll complete, die is at rest");

            //call StoreDieValue function
            StoreDieValue();
        }
        else if (!GetComponent<Rigidbody>().IsSleeping())
        {
            rollComplete = false;
        }
    }
    //Function to store the value of each dice roll into an array and also onto the scoreboard counter
    void StoreDieValue()
    {      

        dieNumberArray[rollCounter] = currentValue;
        //Switch for adding +1 depending on which number is rolled
        switch (currentValue)
        {
            case 1:
                DisplayResultButton.instance.dieNumber1++;
                break;
            case 2:
                DisplayResultButton.instance.dieNumber2++;
                break;
            case 3:
                DisplayResultButton.instance.dieNumber3++;
                break;
            case 4:
                DisplayResultButton.instance.dieNumber4++;
                break;
            case 5:
                DisplayResultButton.instance.dieNumber5++;
                break;
            case 6:
                DisplayResultButton.instance.dieNumber6++;
                break;
            default:
                break;
        }
        //add 1 to rollCounter which happens to be the increment value of the array dieNumberArray
        rollCounter++;
        

    }
}
