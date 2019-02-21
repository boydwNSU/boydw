using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadWords : MonoBehaviour {

	
	void readString()
    {
        string path = "Assets/Resources/test.cpp";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
        Debug.Log("hello");
    }
	
}
