using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    public LoadQuestions[] answers;
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

    private int answerKey = -1;

    public TextAsset testing;

    // List<SavedQuestions> theQuestion = new List<SavedQuestions>();
    
    // Use this for initialization




    void Start()
    {
        TextAsset testing = Resources.Load<TextAsset>("testing");

        string[] data = testing.text.Split(new char[] { ',' });
        Debug.Log(data.Length);

        string[,] eachRow = new string[11,12];
        string[] spanishTitles = new string[6];
        string[] englishTitles = new string[6];


        for (int i = 0; i < data.Length; i++)
        {
          
            Debug.Log(data[i]);
            
        }

        int dataCounter = 0;
        for(int i = 0; i < 11; i++)
        {
            for(int j =0; j < 12; j++)
            {
                eachRow[i, j] = data[dataCounter];
                Debug.Log("EachRow: " + eachRow[i, j]);
                dataCounter++;
            }
            
        }



        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        

        SetCurrentQuestion(data);
    }

    public void SetCurrentQuestion(string[] data)
    {

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        questionText.text = ("What is the proper form of "  );

        
        



    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }








    //[SerializeField]
    //private Animator animator;

/*
     void Start()
     {
         string[] data = testing.text.Split(new char[] { 'n' });

         List<int> row = Enumerable.Range(1, 9).OrderBy(g => System.Guid.NewGuid()).Take(1).ToList();
         Debug.Log(row[0]);
         List<int> columns = Enumerable.Range(1, 6).OrderBy(g => System.Guid.NewGuid()).Take(4).ToList();
         for(int i=0; i < columns.Count; i++)
         {
             Debug.Log(columns[i]);
         }
         int[] intArray = columns.ToArray();
         for (int i = 0; i < intArray.Length; i++)
         {
             Debug.Log("array: " + intArray[i]);
         }

         System.Random randomQuestion = new System.Random();
         Debug.Log("Random: " + intArray[randomQuestion.Next(0, 3)]);

         List<int> cell = columns.Take(1).ToList();
         columns.Skip(1);
         columns = Enumerable.Range(0, 4).OrderBy(g => System.Guid.NewGuid()).Take(4).ToList();
         Debug.Log(cell[0]);

         if(unansweredQuestions == null || unansweredQuestions.Count == 0)
         {
             unansweredQuestions = questions.ToList<Question>();
         }

         SetCurrentQuestion(data, row, cell);
         SetAnswers(data, row, columns, cell);
     }

     public void SetCurrentQuestion(string[] data, List<int> row, List<int> cell)
     {
         string pronouns = data[0];
         string[] pronoun = pronouns.Split(new char[] { ',' });
         string[] englishSpeech = data[row[0]].Split(new char[] { ',' });

         int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
         currentQuestion = unansweredQuestions[randomQuestionIndex];
         questionText.text = "What is the proper form of " + englishSpeech[0] + "\" in Spanish?\n" + pronoun[0] + ":";

     }

     IEnumerator TransitionToNextQuestion()
     {
         unansweredQuestions.Remove(currentQuestion);

         yield return new WaitForSeconds(timeBetweenQuestions);

         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

     }

    public void SetAnswers(string[] data, List<int> row, List<int> columns, List<int> cell)
     {
         string[] spanishSpeech = data[row[0]].Split(new char[] { ',' });

         for(int i = 0; i < columns.Count; i++)
         {
             Debug.Log("column: " + columns[i] + " cells " + cell[0]);
             if (columns[i] == cell[0])
             {
                 //answers[1].isCorrect = true;
                 answerKey = 1;
                 Debug.Log("answerKey: " + answerKey);
             }
            // answers[i].answers = spanishSpeech[columns[i]];
         }
         List<int> choices = Enumerable.Range(0, 4).OrderBy(g => System.Guid.NewGuid()).Take(4).ToList();
         for (int i=0; i < choices.Count; i++)
         {
             Debug.Log("choices" + choices[i]);
         }
         //answer1Text.text = answers[choices[0].answers];
        // answer2Text.text = answers[choices[1].answers];
        // answer3Text.text = answers[choices[2].answers];
         //answer4Text.text = answers[choices[3].answers];
     }

     public void userSelect()
     {
         for(int i = 0; i < answers.Length; i++)
         {
             if(answers[i] == answers[answerKey])
             {
                 //answers[i].isCorrect = true;
                 Debug.Log("Selection is Correct");
                 return;
             }
         }
         Debug.Log("Selection is NOT correct");
     }

  */  

}
