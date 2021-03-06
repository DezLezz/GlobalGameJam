using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMix : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    




}
