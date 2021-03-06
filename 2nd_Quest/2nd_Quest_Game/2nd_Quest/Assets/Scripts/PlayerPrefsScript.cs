using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string LvlProg = "LvlProg";
    private int firstPlayInt;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt(LvlProg, 1);
        }
        //PlayerPrefs.SetInt(LvlProg, 1);
    }
}

