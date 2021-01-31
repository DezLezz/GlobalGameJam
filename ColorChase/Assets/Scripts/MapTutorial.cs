using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapTutorial : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip voiceline;
    public GameObject text;

    public float displayTime = 4.0f;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        audioSource.PlayOneShot(voiceline, 0.5f);
        
    }

    void Update()
    {
        if (text.activeSelf)
        {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0)
            {
                text.SetActive(false);
            }
        }
    }

}
