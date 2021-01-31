using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera firstPersonCamera;
    public Camera mapCamera;
    public AudioListener audioFirstPerson;
    public AudioListener audioMapCam;

    public Sound sound;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled = true;
        mapCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)||Input.GetKeyDown(KeyCode.Space))
        {

            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            mapCamera.enabled = !mapCamera.enabled;
            audioFirstPerson.enabled = !audioFirstPerson.enabled;
            audioMapCam.enabled = !audioMapCam.enabled;

            sound.SoundIsPlaying();
            
        }
    }
}
