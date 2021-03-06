using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    [SerializeField] private Slider backgroundSlider, soundEffectsSlider;
    [SerializeField] private AudioSource clickSound;
    private float backgroundFloat, soundEffectsFloat;
    private GameObject musicObj;
    private AudioSource music;

    void Start()
    {
        musicObj = GameObject.FindGameObjectWithTag("MainMenuMusic");
        music = musicObj.GetComponent<AudioSource>();
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundSlider.value = backgroundFloat*10;
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        soundEffectsSlider.value = soundEffectsFloat*10;
        clickSound.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
    }

    public void GoToMainMenu()
    {
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeMusicVolume()
    {
        clickSound.Play();
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value/10);
        music.volume = PlayerPrefs.GetFloat(BackgroundPref);
    }

    public void ChangeSoundEffectsVolume()
    {
        clickSound.Play();
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value/10);
        clickSound.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
    }

}
