//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;
	private int currentValue = 1;
	public int[] allrolls = new int[20];
	private bool rollComplete = false;
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;
	private int buttonpresses = -1;
	public Text rollText;
	public Text errorText;
	private string chart; //I used this word "chart" to indicate the values of the roll each time

	void Start()
	{
		rollText.text = chart;

		//JC updated the text to indicate the die will roll on its own
		errorText.text = ("welcome child. This is a simulation. " +
			"Press your mouse button to roll the dice, it will roll 20 times, automatically. " +
			"If you press after 20 your game will RESTART :O");
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (buttonName) && buttonpresses == -1) 
		{
			//JC on the first click, the delay makes the game feel laggy so I made it zero
			Invoke ("diceroll", 0);
		}
		else if (GetComponent<Rigidbody>().IsSleeping() && buttonpresses == 19)
		{
			CaptureAndDisplayValues();
			buttonpresses++;
			rollComplete = true;
			Debug.Log ("Dice Roll is Complete");
			errorText.text = ("Good Job Team!");
		}
		if (Input.GetButtonDown (buttonName) && buttonpresses >= 19) { //JC changed to >= due to capture array shift
			SceneManager.LoadScene ("DiceRoller3d");
		}
	}

	void diceroll(){
		buttonpresses = buttonpresses + 1;
		GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
		GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
		Debug.Log ("Button Is Pressed");
		errorText.text = ("Dice is being rolled");
		Invoke ("restart", 3);
	}

	void restart() {
		if (GetComponent<Rigidbody> ().IsSleeping () && !(buttonpresses >= 19)) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) {
				currentValue = hit.collider.GetComponent<DieValue> ().value;
			}
			Debug.Log ("Die roll complete, die is at rest. You may start again");
			//JC changed message to indicate the system is rolling again
			errorText.text = ("one sec while we roll again my sunshine");
			Invoke ("diceroll",1);
			CaptureAndDisplayValues();
		//JC in order to get the last position of the array we need to capture it above
		//and then check our else condition only for less than 19
		} else if (buttonpresses<19){
			Invoke ("restart", 1);
			Debug.Log ("Please Wait until your Die is at rest");
			errorText.text = ("CALCULATING");
		}
	}

	//JC moved these code lines to their own function to allow us to call it directly
	void CaptureAndDisplayValues () {
			allrolls [buttonpresses] = currentValue;
			print (allrolls[buttonpresses]);
			chart = chart + allrolls[buttonpresses].ToString () + " | "; //This is the most important piece of code, stacking all my values
			rollText.text = ("Roll Results: "+ chart ); //reset the text here to have the new extended "chart"
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}

}
