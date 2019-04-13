using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverScore;
    
    // Start is called before the first frame update
    void Start()
    {
        Health.health = 3;
        gameOverScore.text = "Score: " + Score.CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
