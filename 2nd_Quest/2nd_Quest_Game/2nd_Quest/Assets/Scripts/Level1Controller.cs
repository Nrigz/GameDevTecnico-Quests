using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public GameObject TextUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TextUI.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        TextUI.SetActive(false);
    }
}
