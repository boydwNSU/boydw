using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{

    public GameObject instructionsPanel;
    public GameObject trophyRoomPanel;
    public GameObject characterSelectPanel;
    public GameObject levelDifficultyPanel;

    public GameObject bronzeShadow;
    public GameObject silverShadow;
    public GameObject goldShadow;
    public GameObject hiddenText1;
    public GameObject hiddenText2;
    public GameObject hiddenText3;
    public GameObject pinkFrog;
    public GameObject greenFrog;

    public static bool pinkFrogSelected = false;
    public static bool greenFrogSelected = false;
    public static bool easyDifficulty = false;
    public static bool mediumDifficulty = false;
    public static bool hardDifficulty = false;

    // Start is called before the first frame update
    void Start()
    {
        Score.CurrentScore = 0;
        instructionsPanel.gameObject.SetActive(false);
        trophyRoomPanel.gameObject.SetActive(false);

        if (Score.bronzeAchievement == true)
        {
            bronzeShadow.gameObject.SetActive(false);
            hiddenText1.gameObject.SetActive(false);
        }

        if (Score.silverAchievement == true)
        {
            bronzeShadow.gameObject.SetActive(false);
            silverShadow.gameObject.SetActive(false);
            hiddenText1.gameObject.SetActive(false);
            hiddenText2.gameObject.SetActive(false);
        }

        if (Score.goldAchievement == true)
        {
            bronzeShadow.gameObject.SetActive(false);
            silverShadow.gameObject.SetActive(false);
            goldShadow.gameObject.SetActive(false);
            hiddenText1.gameObject.SetActive(false);
            hiddenText2.gameObject.SetActive(false);
            hiddenText3.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ShowLevelDifficulty()
    {
        levelDifficultyPanel.gameObject.SetActive(true);
    }

    public void EasyDifficulty()
    {
        easyDifficulty = true;
    }

    public void MediumDifficulty()
    {
        mediumDifficulty = true;
    }

    public void HardDifficulty()
    {
        hardDifficulty = true;
    }

    public void ShowInstructions()
    {
        instructionsPanel.gameObject.SetActive(true);
    }

    public void RemoveInstructions()
    {
        instructionsPanel.gameObject.SetActive(false);
    }

    public void ShowTrophyRoom()
    {
        trophyRoomPanel.gameObject.SetActive(true);
    }

    public void RemoveTrophyRoom()
    {
        trophyRoomPanel.gameObject.SetActive(false);
    }

    public void ShowCharSelect()
    {
        characterSelectPanel.gameObject.SetActive(true);
    }

    public void RemoveCharSelect()
    {
        characterSelectPanel.gameObject.SetActive(false);
    }

    public void PinkFrogSelected()
    {
        pinkFrogSelected = true;
        pinkFrog.gameObject.SetActive(true);
        greenFrog.gameObject.SetActive(false);
    }

    public void GreenFrogSelected()
    {
        greenFrogSelected = true;
        greenFrog.gameObject.SetActive(true);
        pinkFrog.gameObject.SetActive(false);
    }
}

