//Prin Keerasuntonpong
//4/01/17
//LMSC-281 Roll the Die Simulation Assignment
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResultButton : MonoBehaviour {

    //Declare variables
    public Button yourButton;

    public Text countText1;
    public Text countText2;
    public Text countText3;
    public Text countText4;
    public Text countText5;
    public Text countText6;

    public int dieNumber1 = 0;
    public int dieNumber2 = 0;
    public int dieNumber3 = 0;
    public int dieNumber4 = 0;
    public int dieNumber5 = 0;
    public int dieNumber6 = 0;

    public static DisplayResultButton instance; 
    
    //set instance to this instace
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    //Update dice number score
    void TaskOnClick()
    {
        countText1.text = "Number 1: " + dieNumber1.ToString();
        countText2.text = "Number 2: " + dieNumber2.ToString();
        countText3.text = "Number 3: " + dieNumber3.ToString();
        countText4.text = "Number 4: " + dieNumber4.ToString();
        countText5.text = "Number 5: " + dieNumber5.ToString();
        countText6.text = "Number 6: " + dieNumber6.ToString();
    }
}
