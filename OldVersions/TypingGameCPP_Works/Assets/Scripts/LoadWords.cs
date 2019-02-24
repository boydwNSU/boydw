using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadWords : MonoBehaviour
{
    public TextAsset testing;

    void Start()
    {
        TextAsset testing = Resources.Load<TextAsset>("test");

        string[] data = testing.text.Split(new char[] { '\n' });

        for (int i = 0; i < data.Length; i++)
        {

            Debug.Log(data[i]);

        }
    }

}
