using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreenController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Click");
    }
    
}
