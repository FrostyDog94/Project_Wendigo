using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{

    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        aud.Play();
    }
}
