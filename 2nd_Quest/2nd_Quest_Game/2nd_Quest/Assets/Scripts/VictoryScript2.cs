using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript2 : MonoBehaviour
{
    public GameObject VictoryUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        VictoryUI.SetActive(true);
        if (PlayerPrefs.GetInt("LvlProg") < 3) PlayerPrefs.SetInt("LvlProg", 3);
    }
}
