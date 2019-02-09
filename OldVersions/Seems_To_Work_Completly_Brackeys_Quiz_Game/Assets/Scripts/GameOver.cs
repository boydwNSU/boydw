using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    public Text endScreenScore;
    public int playerScore;

    void Start()
    {
        playerScore = PlayerPrefs.GetInt("Player Score");
        Debug.Log(playerScore);
        endScreenScore.text = "Score: " + playerScore.ToString();
    }


    public void StartGame()
    {
        SceneManager.LoadScene("MenuScreen");
        
    }


}
