//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;
	private int currentValue = 1;
	int[] allrolls = new int[20];
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
	{rollText.text = chart;
		errorText.text = ("welcome child. This is a simulation." +
			"Press your mouse button to roll the dice, only allowed 20 times. " +
			"If you press after 20 your game will RESTART :O");}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (buttonName) && buttonpresses == -1) 
		{
			Invoke ("diceroll", 1);}
		
		 else if (GetComponent<Rigidbody> ().IsSleeping () && buttonpresses == 19) {
			rollComplete = true;
			Debug.Log ("Dice Roll is Complete");
			errorText.text = ("Good Job Team!");
		}
		if (Input.GetButtonDown (buttonName) && buttonpresses == 19) {
			SceneManager.LoadScene ("DiceRoller3d");

		}
	}
	void diceroll(){
		RaycastHit hit;
	buttonpresses = buttonpresses + 1;
	GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
	GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
	Debug.Log ("Button Is Pressed");
	errorText.text = ("Dice is being rolled");
	if (Physics.Raycast (transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) {
		currentValue = hit.collider.GetComponent<DieValue> ().value;}
	Invoke ("restart", 3);}

	void restart() {
		if (GetComponent<Rigidbody> ().IsSleeping () && buttonpresses != 19) {
			allrolls [buttonpresses] = currentValue;
			Debug.Log ("Die roll complete, die is at rest. You may start again");
			errorText.text = ("roll again my sunshine");
			print (allrolls[buttonpresses]);
			chart = chart + allrolls[buttonpresses].ToString () + " | "; //This is the most important piece of code, stacking all my values
			rollText.text = ("Roll Results: "+ chart ); //reset the text here to have the new extended "chart"
		Invoke ("diceroll",1);
			
		} else {
			Invoke ("restart", 1);
			Debug.Log ("Please Wait until your Die is at rest");
			errorText.text = ("CALCULATING");
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}

}
