using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triggerTutorialMessage : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip voiceline;
    public GameObject text;

    public void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        audioSource.PlayOneShot(voiceline, 0.5f);
    }

    public void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        audioSource.Stop();
    }
}
