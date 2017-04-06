using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//JC include SceneManegement to restart the level
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//JC you have a public int DieRoll in both this script and the applyrandomforce script
	public int DieRoll = 20;
	public GameObject restartButton;

	// Use this for initialization
	void Start () 
	{
		restartButton.SetActive (false);

		//JC since we now have a boolean telling us when the die is ready to roll, we can use that instead of an Invoke method
		//furthr, we need to do this in the Update() function so that it is checking continuously during the game
//		InvokeRepeating ("Die", 1, 1);
//			
//		while (DieRoll > 0)
//		{
//			DieRoll--;
//		}
	}

	public void Update ()
	{
		if (DieRoll == 0) 
		{
			GameOver ();
		}
		//JC if we can roll the die again, roll it
		else if (GetComponent<ApplyForceInRandomDirection>().readyToThrow){
			//JC let's use your "Throw" function here
			GetComponent<ApplyForceInRandomDirection>().Throw();
			DieRoll--;
		}
	}

	void GameOver ()
	{	
		restartButton.SetActive (true);
	}

	// Update is called once per frame
	public void RestartGame ()
	{
		SceneManager.LoadScene("DiceRoller3D");
		restartButton.SetActive (false);
	}

}
