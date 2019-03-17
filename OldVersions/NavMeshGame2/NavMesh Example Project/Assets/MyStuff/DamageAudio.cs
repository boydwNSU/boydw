using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAudio : MonoBehaviour
{

    public AudioClip DamageSound;

    public AudioSource DamageSource;
    // Start is called before the first frame update
    void Start()
    {
        DamageSource.clip = DamageSound;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
