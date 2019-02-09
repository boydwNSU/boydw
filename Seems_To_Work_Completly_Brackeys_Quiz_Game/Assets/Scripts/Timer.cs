using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {


    public GameObject gameOverPanel;

    [SerializeField]
    private Text timerText;

    public float timeLeft = 30.0f;

	// Use this for initialization
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + timeLeft.ToString("0");
        if(timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
            
            
        }
	}
	
}
