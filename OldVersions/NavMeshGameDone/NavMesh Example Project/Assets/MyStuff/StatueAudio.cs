using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAudio : MonoBehaviour
{

    public AudioClip StatueSound;

    public AudioSource StatueSource;
    // Start is called before the first frame update
    void Start()
    {
        StatueSource.clip = StatueSound;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
