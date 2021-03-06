using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlSel1 : MonoBehaviour
{
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    [SerializeField] private AudioSource clickSound;
    private GameObject music;


    void Start()
    {
        music = GameObject.FindGameObjectWithTag("MainMenuMusic");
        clickSound.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
    }
    public void GoToMainMenu()
    {
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        Destroy(music);
        clickSound.Play();
        SceneManager.LoadScene("Level1");
    }

    public void PreviousLevel()
    {
        clickSound.Play();
        SceneManager.LoadScene("LevelSel3Menu");
    }

    public void NextLevel()
    {
        clickSound.Play();
        SceneManager.LoadScene("LevelSel2Menu");
    }
}
