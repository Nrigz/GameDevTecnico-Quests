using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graves2 : MonoBehaviour
{
    public GameObject player;
    public PlayerController script;
    public GameObject InvUI;
    public GameObject InvUI2;
    // Start is called before the first frame update
    void Start()
    {
        script = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.gravesDestroyed == 2)
        {
            InvUI.SetActive(false);
            InvUI2.SetActive(true);
        }
        
    }
}
