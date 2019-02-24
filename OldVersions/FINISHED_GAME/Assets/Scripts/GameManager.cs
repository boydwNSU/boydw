using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel;

    public Question[] questions;
    public static List<Question> unansweredQuestions;

    public Question currentQuestion;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text answer1Text;

    [SerializeField]
    private Text answer2Text;

    [SerializeField]
    private Text answer3Text;

    [SerializeField]
    private Text answer4Text;

    [SerializeField]
    private float timeBetweenQuestions = 1f;
    

    public TextAsset testing;

    // List<SavedQuestions> theQuestion = new List<SavedQuestions>();

    // Use this for initialization

    [SerializeField]
    private Animator animator;

    public Text scoreDisplayText;
    public Text endGameScore;
    public int pointsAddedForCorrectAnswer = 100;
    public int pointsSubtractedForWrongAnswer = 50;
    public int playerScore = 0;


    string[] spanishTitles = new string[6];
    string[] englishTitles = new string[6];
    string[,] spanishTranslations = new string[10, 6];
    string[,] englishTranslations = new string[10, 6];

    public string answerKey;
    

    void Start()
    {
        gameOverPanel.SetActive(false);

        TextAsset testing = Resources.Load<TextAsset>("testing");

        string[] data = testing.text.Split(new char[] { ',' });
        //Debug.Log(data.Length);

        string[,] eachRow = new string[11, 12];



        for (int i = 0; i < data.Length; i++)
        {

            //Debug.Log(data[i]);

        }

        int dataCounter = 0;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                eachRow[i, j] = data[dataCounter];
                // Debug.Log("EachRow: " + eachRow[i, j]);
                dataCounter++;
            }

        }

        for (int i = 0; i < 6; i++)
        {
            spanishTitles[i] = eachRow[0, i];
            //Debug.Log("Spanish Titles: " + spanishTitles[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            englishTitles[i] = eachRow[0, i + 6];
            //Debug.Log("English Titles: " + englishTitles[i]);
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                spanishTranslations[i, j] = eachRow[i + 1, j];
                //Debug.Log("Spanish Translations: " + spanishTranslations[i, j]);

            }

        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                englishTranslations[i, j] = eachRow[i + 1, j + 6];
                //Debug.Log("English Translations: " + englishTranslations[i, j]);

            }

        }
        
        SetCurrentQuestion(spanishTitles, englishTitles, spanishTranslations, englishTranslations);
        

    }

    public void SetCurrentQuestion(string[] spanishTitles, string[] englishTitles, string[,] spanishTranslations, string[,] englishTranslations)
    {

        int randomColumn = Random.Range(0, 5);
        int randomRow = Random.Range(0, 9);
        
        questionText.text = ("What is the proper form of '" + englishTitles[randomColumn] + ": " + englishTranslations[randomRow, randomColumn] + "' in Spanish?  \n'" + spanishTitles[randomColumn] + ":' ");
        SetAnswers(spanishTitles, englishTitles, spanishTranslations, englishTranslations, randomColumn, randomRow);



    }

    IEnumerator TransitionToNextQuestion()
    {

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void SetAnswers(string[] spanishTitles, string[] englishTitles, string[,] spanishTranslations, string[,] englishTranslations, int randomColumn, int randomRow)
    {

        int randomPlacement = Random.Range(0, 4);
        Debug.Log(randomPlacement);

        int randomAnswer1 = Random.Range(0, 5);
        int randomAnswer2 = Random.Range(0, 5);
        int randomAnswer3 = Random.Range(0, 5);

        string correctAnswer = spanishTranslations[randomRow, randomColumn];
        string wrongAnswer1 = spanishTranslations[randomRow, randomAnswer1];
        string wrongAnswer2 = spanishTranslations[randomRow, randomAnswer2];
        string wrongAnswer3= spanishTranslations[randomRow, randomAnswer3];

        while(wrongAnswer1 == correctAnswer || wrongAnswer1 == wrongAnswer2 || wrongAnswer1 == wrongAnswer3 || wrongAnswer2 == wrongAnswer3 || wrongAnswer2 == correctAnswer || wrongAnswer3 ==correctAnswer)
        {
            randomAnswer1 = Random.Range(0, 5);
            randomAnswer2 = Random.Range(0, 5);
            randomAnswer3 = Random.Range(0, 5);

            wrongAnswer1 = spanishTranslations[randomRow, randomAnswer1];
            wrongAnswer2 = spanishTranslations[randomRow, randomAnswer2];
            wrongAnswer3 = spanishTranslations[randomRow, randomAnswer3];
        }

        if(randomPlacement == 0)
        {
            answer1Text.text = correctAnswer;
            answer2Text.text = wrongAnswer1;
            answer3Text.text = wrongAnswer2;
            answer4Text.text = wrongAnswer3;

        }
        if (randomPlacement == 1)
        {
            answer1Text.text = wrongAnswer1; 
            answer2Text.text = correctAnswer;
            answer3Text.text = wrongAnswer2;
            answer4Text.text = wrongAnswer3;

        }
        if (randomPlacement == 2)
        {
            answer1Text.text = wrongAnswer1;
            answer2Text.text = wrongAnswer2;
            answer3Text.text = correctAnswer;
            answer4Text.text = wrongAnswer3;

        }
        if (randomPlacement == 3)
        {
            answer1Text.text = wrongAnswer1;
            answer2Text.text = wrongAnswer2;
            answer3Text.text = wrongAnswer3;
            answer4Text.text = correctAnswer;

        }

        answerKey = correctAnswer;

    }

    public void AnswerButton1Clicked()
    {
        if (answer1Text.text == answerKey)
        {
            Debug.Log("Correct");
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            SetCurrentQuestion(spanishTitles, englishTitles, spanishTranslations, englishTranslations);
        }
        else
        {
            Debug.Log("Wrong");
            playerScore -= pointsSubtractedForWrongAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            answer1Text.text = "INCORRECT";
        }

        
    }
  

    
    public void AnswerButton2Clicked()
    {
        if (answer2Text.text == answerKey)
        {
            Debug.Log("Correct");
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            SetCurrentQuestion(spanishTitles, englishTitles, spanishTranslations, englishTranslations);
        }
        else
        {
            Debug.Log("Wrong");
            playerScore -= pointsSubtractedForWrongAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            answer2Text.text = "INCORRECT";
        }

        

    }

    public void AnswerButton3Clicked()
    {
        if (answer3Text.text == answerKey)
        {
            Debug.Log("Correct");
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            SetCurrentQuestion(spanishTitles, englishTitles, spanishTranslations, englishTranslations);
        }
        else
        {
            Debug.Log("Wrong");
            playerScore -= pointsSubtractedForWrongAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            answer3Text.text = "INCORRECT";
        }

    }

    public void AnswerButton4Clicked()
    {
        if (answer4Text.text == answerKey)
        {
            Debug.Log("Correct");
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            SetCurrentQuestion(spanishTitles, englishTitles, spanishTranslations, englishTranslations);
        }
        else
        {
            Debug.Log("Wrong");
            playerScore -= pointsSubtractedForWrongAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            endGameScore.text = "Score: " + playerScore.ToString();
            answer4Text.text = "INCORRECT";
        }




    }
}  






