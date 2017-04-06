using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int DieRoll = 20;
	public GameObject restartButton;

	// Use this for initialization
	void Start () 
	{
		restartButton.SetActive (false);

		InvokeRepeating ("Die", 1, 1);
			
		while (DieRoll > 0)
		{
			DieRoll--;
		}
	}

	public void Update ()
	{
		if (DieRoll <= 0) 
		{
			GameOver ();
		}
	}

	void GameOver ()
	{	
		restartButton.SetActive (true);
	}

	// Update is called once per frame
	public void RestartGame ()
	{
		restartButton.SetActive (false);
	}

}
