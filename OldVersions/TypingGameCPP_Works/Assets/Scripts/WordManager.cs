using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;
    

    /*
    void Start()
    {
        string path = "Assets/Resources/test.cpp";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log("Hello");
        // Debug.Log(reader.ReadToEnd());
        // Debug.Log("Hello");
        string line;
        int counter = 0;
        string[] myWords = new string[22];
        while((line = reader.ReadLine()) != null)
        {
            myWords[counter] = line;
            Debug.Log(myWords[counter].TrimStart());
            counter++;
        }
        reader.Close();
        
    }
    */



    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }

    

}
