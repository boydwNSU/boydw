using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public static int numOfPoints = 100;

	void OnTriggerEnter2D ()
	{
		Debug.Log("YOU WON!");
		Score.PointsThisLife += numOfPoints;
        Score.TotalPoints += numOfPoints;

        if(Score.PointsThisLife > Score.HighestPointCount)
        {
            Score.HighestPointCount = Score.PointsThisLife;
        }

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
