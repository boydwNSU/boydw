using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static int PointsThisLife = 0;
    public static int HighestPointCount = 0;
    public static int TotalPoints = 0;
    public static int Lives = 3;


    public Text text;
    public Text CurrentInfo;

    void Start()
    {
    }

    void Update()
    {
        CurrentInfo.text = ""; // reset content to nothing
        text.text = PointsThisLife.ToString();
        CurrentInfo.text += "Player: " + Scenes.playerName + "\nPoints This Life: " + PointsThisLife + "\nHighest Points: " + HighestPointCount + "\nTotal Points: " + TotalPoints + "\nLives Remaining: " + Lives;

        if(Lives == 0)
        {
            SceneManager.LoadScene("Exit");
            Lives = 3;
        }
        
    }

}
