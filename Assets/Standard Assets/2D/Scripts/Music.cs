using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Music : MonoBehaviour
{
    // audio
    public AudioClip future;
    public AudioClip past;
    public AudioSource FSoundSource;
    public AudioSource PSoundSource;

    private double maxVol = 0.5;
    private float fadeAmount = 0.02f;

    private bool muted = false;

    void Start()
    {
        FSoundSource.clip = future;
        PSoundSource.clip = past;

        FSoundSource.loop = true;
        PSoundSource.loop = true;

        FSoundSource.Play();
        PSoundSource.Play();

        FSoundSource.volume = 0f;
        PSoundSource.volume = 0f;
    }

    void FixedUpdate()
    {
        if (muted) return;

        if(Platformer2DUserControl.inFuture) // future music 
        {
            if(FSoundSource.volume < maxVol) FSoundSource.volume += fadeAmount;
            if (PSoundSource.volume > 0.0) PSoundSource.volume -= fadeAmount;
        }
        else if (!Platformer2DUserControl.inFuture) //past music
        {
            if (FSoundSource.volume > 0.0) FSoundSource.volume -= fadeAmount;
            if (PSoundSource.volume < maxVol) PSoundSource.volume += fadeAmount;
        }
    }

    void toggleMute()
    {
        if(muted)
        {
            muted = false;
        }
        else
        {
            FSoundSource.volume = 0f;
            PSoundSource.volume = 0f;
        }
    }
}
