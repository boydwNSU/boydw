using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]

    public void StartGame()
    {
        SceneManager.LoadScene("MenuScreen");

    }


}
