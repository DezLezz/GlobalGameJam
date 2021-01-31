using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "endDoor")
        {
            SceneManager.LoadScene(2);
        }
    }

}
