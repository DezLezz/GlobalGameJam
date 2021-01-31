using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class goToMenu : MonoBehaviour
{
    public Button start;

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ButtonStart()
    {

        SceneManager.LoadScene(0);
    }

    
}
