using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System;

public class WriteScores : MonoBehaviour
{
    public Text Summary;

    public Text HighScoreText;
    int scorerNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        Summary.text = "Player: " + Scenes.playerName + "\nHighest Points: " + Score.HighestPointCount + "\nTotal Points: " + Score.TotalPoints; //correct over count of rounds


    }

    public void WriteTheScores()
    {
        //first read the current scores file
        int playerScore; // first field in record
        string playerName; // second field in record
        string[] readText; // array of lines in file
        string[] fields; // fields in the line
        bool currentScoreWritten = false; // the current score has not beeen recorded in the file
        string path = "Assets/Resources/scores.txt";

        readText = File.ReadAllLines(path);
        Debug.Log("Working Up Here");

        foreach (string line in readText)
        {
            fields = line.Split(',');
            Debug.Log("WORKING");
            playerScore = Convert.ToInt32(fields[0]);
            playerName = fields[1];

            if (scorerNumber <= 10)
            {
                HighScoreText.text += scorerNumber + ". " + playerName + " - " + playerScore + "\n";
                scorerNumber++;
            }

        }
        StreamWriter writer = new StreamWriter(path);
        foreach (string line in readText)
        {
            fields = line.Split(',');
            if (Convert.ToInt32(fields[0]) < Score.TotalPoints && currentScoreWritten == false) 
            {
                Debug.Log("Here");   
                writer.Write(Score.TotalPoints); 
                writer.Write(','); 
                writer.Write(Scenes.playerName); 
                writer.Write("\n"); 
                Summary.text += Scenes.playerName + " - " + Score.TotalPoints + "\n"; 
                writer.Write(line + "\n"); 
                Summary.text += fields[1]  + " - " + fields[0] + "\n"; 
                currentScoreWritten = true; 
            }
            else
            {
                Debug.Log("The Else");
                writer.Write(line + "\n"); 
            }
            
        }
        writer.Close();
        
        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("scores"); // NEED TO CAST AS A TEXT ASSET SO IT CAN BE USED. TRY WITHOUT.

        //Print the text from the file
        Debug.Log("scores updated");


    }
}
