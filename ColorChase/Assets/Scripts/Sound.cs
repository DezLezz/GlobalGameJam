using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource audioSource;


    public AudioSource button;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public AudioSource extrasounds;
    public AudioSource extrasounds2;

    public void SoundIsPlaying()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public void HoverSound()
    {
        button.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        button.PlayOneShot(clickSound);
    }


    



}