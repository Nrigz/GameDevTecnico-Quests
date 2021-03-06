using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private GameObject music;
    [SerializeField] private AudioSource clickSoundEffect;
    private static readonly string FirstPlay = "FirstPlay";
    private int firstPlayInt;


    public void Start()
    {
        music = GameObject.FindGameObjectWithTag("MainMenuMusic");
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

    }

    public void PlayGame()
    {
        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
            
        clickSoundEffect.Play();
        SceneManager.LoadScene("LevelSel1Menu");
    }

    public void GoToSettingsMenu()
    {
        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        clickSoundEffect.Play();
        SceneManager.LoadScene("SettingsMenu");
    }

    public void QuitGame()
    {
        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        clickSoundEffect.Play();
        Application.Quit();
    }

    
}
