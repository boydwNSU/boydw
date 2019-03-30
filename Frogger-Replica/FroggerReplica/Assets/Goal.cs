using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    

	void OnTriggerEnter2D ()
	{
		Debug.Log("YOU WON!");
		Score.CurrentScore += 100;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Score.CurrentScore == 500)
        {
            Score.bronzeAchievement = true;
        }
        else if(Score.CurrentScore == 1000)
        {
            Score.bronzeAchievement = true;
            Score.silverAchievement = true;
        }
        else if (Score.CurrentScore == 2500)
        {
            Score.bronzeAchievement = true;
            Score.silverAchievement = true;
            Score.goldAchievement = true;
        }
	}

    

}
