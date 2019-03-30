using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int CurrentScore = 0;

    public GameObject achievementUnlocked;
    public static bool bronzeAchievement = false;
    public static bool silverAchievement = false;
    public static bool goldAchievement = false;

    public Text scoreText;

	void Start ()
	{
		scoreText.text = CurrentScore.ToString();
        if (CurrentScore == 500 || CurrentScore == 1000 || CurrentScore == 2500)
        {
            achievementUnlocked.gameObject.SetActive(true);
            Invoke("RemoveAchievementUnlocked", 3f);
        }
        
    }

    public void RemoveAchievementUnlocked()
    {
        achievementUnlocked.gameObject.SetActive(false);
    }

}
