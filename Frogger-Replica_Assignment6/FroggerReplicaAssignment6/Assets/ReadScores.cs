using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System; // for conversion

public class ReadScores : MonoBehaviour
{
    public Text HighScoreText;
    int scorerNumber = 1;

    // Start is called before the first frame update
    void Start() // we read the file on loading the page, the script is attached to the camera so it will always run.
    {
        int playerScore; // first field in record
        string playerName; // second field in record
        string[] readText; // array of lines in file
        string[] fields; // fields in the line

        string path = "Assets/Resources/scores.txt";

        readText = File.ReadAllLines(path);

        foreach (string line in readText)
        {
            fields = line.Split(',');
            playerScore = Convert.ToInt32(fields[0]);
            playerName = fields[1];
            if (scorerNumber <= 10)
            {
                HighScoreText.text += scorerNumber + ". " + playerName + " - " + playerScore + "\n";
                scorerNumber++;
            }  
        }


    }

}
