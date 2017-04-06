//Prin Keerasuntonpong
//4/01/17
//LMSC-281 Roll the Die Simulation Assignment
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
    //Delare public variables
    public Button yourButton;

    void Start()
    {
        //Get component from gameObject
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    //Unity function for clicking button
    void TaskOnClick()
    {
        //Reload scene
        SceneManager.LoadScene("DiceRoller3d");
    }
}
