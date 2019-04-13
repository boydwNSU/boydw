using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    public static string playerName;
    public InputField PlayerNameInputField;

    public void Intro1()
    {
        SceneManager.LoadScene("Intro");
        
    }

    public void Scores2()
    {
        
        SceneManager.LoadScene("Scores");
    }

    public void Main3()
    {
        if (string.IsNullOrEmpty(PlayerNameInputField.text))
        {
            playerName = "Anonymous";
        }
        else
        {
            playerName = PlayerNameInputField.text;
        }
        Score.TotalPoints = 0;
        Score.HighestPointCount = 0;
        Debug.Log(playerName);
        SceneManager.LoadScene("Main");
    }

    public void Exit4()
    {
        SceneManager.LoadScene("Exit");
    }

    public void QuitGame()
    {
        //exit application for real:
        // Application.Quit();

        // for development:
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
