using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	//Create restart button
	void OnGUI (){
		if (GUI.Button (new Rect (50f, 50f, 150, 50), new GUIContent ("Restart"))) {
			SceneManager.LoadScene ("DiceRoller3d");
		}
	}
}
