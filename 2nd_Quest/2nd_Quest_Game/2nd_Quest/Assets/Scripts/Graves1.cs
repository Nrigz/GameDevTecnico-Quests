using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graves1 : MonoBehaviour
{
    public GameObject player;
    public PlayerController script;
    public GameObject InvUI;
    // Start is called before the first frame update
    void Start()
    {
        script = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.gravesDestroyed == 1) InvUI.SetActive(false);
    }
}
