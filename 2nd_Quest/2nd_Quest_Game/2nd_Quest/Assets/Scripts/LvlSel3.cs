using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlSel3 : MonoBehaviour
{
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private GameObject StartUI;
    private static readonly string LvlProg = "LvlProg";
    private int lvlProg;
    private GameObject music;

    void Start()
    {
        lvlProg = PlayerPrefs.GetInt(LvlProg);
        if (lvlProg > 2)
        {
            StartUI.SetActive(true);
        }
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
        SceneManager.LoadScene("Level3");
    }

    public void PreviousLevel()
    {
        clickSound.Play();
        SceneManager.LoadScene("LevelSel2Menu");
    }

    public void NextLevel()
    {
        clickSound.Play();
        SceneManager.LoadScene("LevelSel1Menu");
    }
}
