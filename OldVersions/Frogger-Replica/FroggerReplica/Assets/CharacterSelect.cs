using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject greenFrogSprite;
    public GameObject pinkFrogSprite;

    // Start is called before the first frame update
    void Start()
    {
        if(StartMenuManager.greenFrogSelected == true)
        {
            greenFrogSprite.gameObject.SetActive(true);
        }
        else if(StartMenuManager.pinkFrogSelected == true)
        {
            pinkFrogSprite.gameObject.SetActive(true);
        }
        else
        {
            greenFrogSprite.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
