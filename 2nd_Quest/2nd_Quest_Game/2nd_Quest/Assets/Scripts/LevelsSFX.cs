using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsSFX : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    public AudioSource music;
    public AudioSource[] soundEffects;
    private float backgroundFloat, soundEffectsFloat;
    void Start()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        music.volume = backgroundFloat;

        for (int i = 0; i < soundEffects.Length; i++)
        {
            soundEffects[i].volume = soundEffectsFloat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
