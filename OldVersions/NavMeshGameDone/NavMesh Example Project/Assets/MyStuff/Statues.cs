using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statues : MonoBehaviour
{
    public int statuesCollected;
    public int numOfStatues;

    public int statuesPlayerHas = 0;

    public GameObject statue1;
    public GameObject statue2;
    public GameObject statue3;

    public Image[] statues;
    public Sprite fullStatue;
    public Sprite emptyStatue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < statues.Length; i++)
        {
            if (i < numOfStatues)
            {
                statues[i].sprite = fullStatue;
            }
            else
            {
                statues[i].sprite = emptyStatue;
            }


            if (i < numOfStatues)
            {
                statues[i].enabled = true;
            }
            else
            {
                statues[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        statuesPlayerHas++;
    }
    
}



