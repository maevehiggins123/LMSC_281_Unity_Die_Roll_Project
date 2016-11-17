//Aaron Spieldenner
//LMSC-281
//Fall 2016
//Die Roll Project
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (400f, 0f, 150, 50), new GUIContent ("Restart"))) {
			SceneManager.LoadScene ("DiceRoller3d");
		}
	}
}

