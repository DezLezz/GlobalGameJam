using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button quit;
    public Button restart;
    public Button settings;
    public Button resume;
    public GameObject firstPP;
    public GameObject mapP;
    public GameObject camController;
    public bool EscapeMenuOpen = false;
    public int currentCam = 0;
    public GameObject settingsMenu;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenuOpen == false)
            {
                quit.gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
                settings.gameObject.SetActive(true);
                resume.gameObject.SetActive(true);
                EscapeMenuOpen = true;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

                if (firstPP.GetComponent<PlayerMovement>().enabled)
                {
                    currentCam = 0;
                }
                else
                {
                    currentCam = 1;
                }

                camController.SetActive(false);
                firstPP.GetComponent<PlayerMovement>().enabled = false;
                mapP.GetComponent<PlayerMovement2D>().enabled = false;
            }
            else
            {
                quit.gameObject.SetActive(false);
                restart.gameObject.SetActive(false);
                settings.gameObject.SetActive(false);
                resume.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                EscapeMenuOpen = false;

                camController.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                if (currentCam == 0)
                {
                    firstPP.GetComponent<PlayerMovement>().enabled = true;
                }
                else
                {
                    mapP.GetComponent<PlayerMovement2D>().enabled = true;
                }
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void Settings()
    {
        settingsMenu.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
    }

    public void Resume()
    {
        EscapeMenuOpen = false;
        quit.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        EscapeMenuOpen = false;

        camController.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   

        if (currentCam == 0)
        {
            firstPP.GetComponent<PlayerMovement>().enabled = true;
        }
        else
        {
            mapP.GetComponent<PlayerMovement2D>().enabled = true;
        }
    }

    public void Back()
    {
        settingsMenu.gameObject.SetActive(false);
        quit.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
    }
}
