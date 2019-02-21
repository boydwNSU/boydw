using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = new string[9];

    static void readFile()
    {
        string path = "Assets/Resources/test.cpp";
        
        StreamReader reader = new StreamReader(path);
        Debug.Log("Hello");
        string line;
        int counter = 0;
        
        while ((line = reader.ReadLine()) != null)
        {
            wordList[counter] = line.TrimStart();
            Debug.Log(wordList[counter].TrimStart());
            counter++;
        }
        reader.Close();

    }
    /*
    private static string[] wordList = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                                        "sidewalk", "robin", "protect", "periodic","cream","scarce",
                                        "somber", "majestic", "jump", "pretty", "wound", "jazzy",
                                        "memory", "join", "crack", "grade", "boot", "cloudy", "sick",
                                        "mug", "hot", "tart", "dangerous", "mother", "rustic", "economic",
                                        "weird", "cut", "parallel", "wood", "encouraging", "interrupt",
                                        "guide", "long", "chief", "mom", "signal", "rely", "abortive",
                                        "hair", "representative", "earth", "grate", "proud", "feel",
                                        "hilarious", "addition", "silent", "play", "floor", "numerous",
                                        "friend", "pizzas", "building", "organic", "pasat", "mute", "unusual",
                                        "mellow", "analyse", "crate", "homely", "protest", "painstaking",
                                        "society", "head", "female", "eager", "heap", "dramatic", "present",
                                        "sin", "box", "pies", "awesome", "root", "available", "sleet", "wax",
                                        "boring", "smash", "anger", "tasty", "spare", "tray", "daffy", 
                                        "account", "spot", "thought", "distinct", "nimble", "practice", 
                                        "ablaze", "thoughtless", "love", "verdict", "giant"};
*/

    public static string GetRandomWord()
    {
        readFile();
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }

}
