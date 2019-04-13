using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int health = 3;

    public GameObject frogHeart1;
    public GameObject frogHeart2;
    public GameObject frogHeart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 3)
        {
            frogHeart1.gameObject.SetActive(true);
            frogHeart2.gameObject.SetActive(true);
            frogHeart3.gameObject.SetActive(true);
        }
        else if(health == 2)
        {
            frogHeart1.gameObject.SetActive(false);
        }
        else if (health == 1)
        {
            frogHeart1.gameObject.SetActive(false);
            frogHeart2.gameObject.SetActive(false);
        }
        else if (health == 0)
        {
            frogHeart1.gameObject.SetActive(false);
            frogHeart2.gameObject.SetActive(false);
            frogHeart3.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
            
        }
    }
}
