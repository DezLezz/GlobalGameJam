using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickUp : MonoBehaviour
{
    public GameObject FPPHeart;
    public GameObject mHeart;

    public GameObject endDoor;
    public GameObject secondEndDoor;

    public GameObject FPPLevel;
    public GameObject mLevel;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;

    public Material blue;
    public Material green;
    public Material red;
    public Material yellow;

    public Material skybox;

    public Material wall_mat;

    public ParticleSystem redExplosion;
    public ParticleSystem greenExplosion;
    public ParticleSystem blueExplosion;
    public ParticleSystem yellowExplosion;
    

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource audioSource2;
    public AudioClip audioClip2;

    public AudioSource audioSource3;

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;

    public bool changeColours = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "heart")
        {
            audioSource.PlayOneShot(audioClip);
            audioSource2.Play();
            changeColours = true;
            FPPHeart.SetActive(false);
            mHeart.SetActive(false);

        }
    }

    public void Update()
    {
        if (changeColours)
        {
            RenderSettings.skybox = skybox;
            redExplosion.Emit(200);
            blueExplosion.Emit(200);
            greenExplosion.Emit(200);
            yellowExplosion.Emit(200);
            endDoor.SetActive(true);
            secondEndDoor.SetActive(true);

            canvas1.SetActive(true);
            canvas2.SetActive(true);
            canvas3.SetActive(true);

            wall1.GetComponent<MeshRenderer>().material = wall_mat;
            wall2.GetComponent<MeshRenderer>().material = wall_mat;
            wall3.GetComponent<MeshRenderer>().material = wall_mat;
            wall4.GetComponent<MeshRenderer>().material = wall_mat;

            foreach (Transform block in FPPLevel.transform)
            {
                //block.gameObject.GetComponent<MeshRenderer>().material

                if (block.name.Contains("Blue"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = blue;
                    block.gameObject.layer = 8;
                }
                else if (block.name.Contains("Cyan"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = blue;
                    block.gameObject.layer = 8;
                }
                else if (block.name.Contains("Green"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = green;
                    block.gameObject.layer = 9;
                }
                else if (block.name.Contains("Lime"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = green;
                    block.gameObject.layer = 9;
                }
                else if (block.name.Contains("Orange"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    block.gameObject.layer = 11;
                }
                else if (block.name.Contains("Yellow"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    block.gameObject.layer = 11;
                }
                else if (block.name.Contains("Pink"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = red;
                    block.gameObject.layer = 10;
                }
                else if (block.name.Contains("Red"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = red;
                    block.gameObject.layer = 10;
                }

            }

            foreach (Transform block in mLevel.transform)
            {
                //block.gameObject.GetComponent<MeshRenderer>().material

                if (block.name.Contains("Blue"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = blue;
                    block.gameObject.layer = 8;
                }
                else if (block.name.Contains("Cyan"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = blue;
                    block.gameObject.layer = 8;
                }
                else if (block.name.Contains("Green"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = green;
                    block.gameObject.layer = 9;
                }
                else if (block.name.Contains("Lime"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = green;
                    block.gameObject.layer = 9;
                }
                else if (block.name.Contains("Orange"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    block.gameObject.layer = 11;
                }
                else if (block.name.Contains("Yellow"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    block.gameObject.layer = 11;
                }
                else if (block.name.Contains("Pink"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = red;
                    block.gameObject.layer = 10;
                }
                else if (block.name.Contains("Red"))
                {
                    block.gameObject.GetComponent<MeshRenderer>().material = red;
                    block.gameObject.layer = 10;
                }

            }

            changeColours = false;
        }
    }

}
