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

	//while instancing can work in some situations, it is unnecessary here, as we can directly reference this class
    //public static DisplayCurrentDieValue instance;

	//Grabbing number of rolls from the public variable
	//JC we can more simply grab the specific component in the Start function
    //public int[] dieNumberArray = new int[ApplyForceInRandomDirection.instance.numberOfRolls];
	public int[] dieNumberArray;

	//JC begin your counter at 0, to match the way an array position begins
    public int rollCounter = 0;

//    void Awake()
//    {
//        instance = this;
//    }
    
    void Start()
    {
		dieNumberArray = new int[GetComponent<ApplyForceInRandomDirection>().numberOfRolls];
        string testWriteArray = dieNumberArray.Length.ToString();
        Debug.Log("Length of dieNumberArray is" + testWriteArray); 
    }

    void Update ()
	{
        //call DiceRoll method
		if ((rollCounter >= 0) && (rollCounter < GetComponent<ApplyForceInRandomDirection>().numberOfRolls)) {
        	DiceValue();
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}


    void DiceValue()
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
			if (rollCounter < GetComponent<ApplyForceInRandomDirection>().numberOfRolls) {
            	StoreDieValue();
			}
			//JC we can wait until the end to write to the text file
//			GetComponent<WriteResultsToText>().WriteArray();
//            WriteResultsToText.instance.WriteArray();
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
