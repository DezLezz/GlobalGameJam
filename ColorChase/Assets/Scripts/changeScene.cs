using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class changeScene : MonoBehaviour
{
    public Button start;
    public Button credits;
    public Button settings;
    public Button quit;
    public Button back;

    public TextMeshProUGUI gameName;
    public TextMeshProUGUI creditsText;

    public GameObject main;
    public GameObject credits_obj;
    public GameObject settings_obj;

    public Sound sound;

    public void Start()
    {
        sound.SoundIsPlaying();
    }
    public void ButtonStart()
    {

        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        main.SetActive(false);
        credits_obj.SetActive(true);
    }

    public void Settings()
    {
        main.SetActive(false);
        settings_obj.SetActive(true);
    }

    public void Back()
    {
        main.SetActive(true);
        credits_obj.SetActive(false);
    }

    public void Back2()
    {
        main.SetActive(true);
        settings_obj.SetActive(false);
    }
}
