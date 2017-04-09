//LMSC-281
//Spring 2017
//Print results from array into text file
//PRIN KEERASUNTONPONG

using System.Collections;
using UnityEngine;
using System.IO;

public class WriteResultsToText : MonoBehaviour {

    string fileToWriteTo;

    public bool runWriteArray = false;

    public string stringOfValues;

    public static WriteResultsToText instance; 

    void Awake()
    {
        instance = this; 
    }

	void Start ()
    {

        fileToWriteTo = Application.dataPath + "/Resources/Data.txt";
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void WriteArray()
    {
        for (int i = 0; i < DisplayCurrentDieValue.instance.dieNumberArray.Length; i++)
        {
            int intArrayValue = DisplayCurrentDieValue.instance.dieNumberArray[i];
            stringOfValues = stringOfValues + intArrayValue.ToString();
        }

        stringOfValues = stringOfValues + "\r\n"; 
        //Using the append function to write the data out to a text file
        File.AppendAllText(fileToWriteTo, stringOfValues);

        //overwrite the information in the text file
        File.WriteAllText(fileToWriteTo, stringOfValues); 
    }

}
