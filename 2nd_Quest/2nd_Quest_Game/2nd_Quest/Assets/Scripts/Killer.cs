using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    private Vector3 newPos;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        newPos = spawn.transform.position;
        player.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
    }
}
