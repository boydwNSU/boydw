using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{

    public AudioClip DeathSound;

    public AudioSource DeathSource;
    // Start is called before the first frame update
    void Start()
    {
        DeathSource.clip = DeathSound;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
