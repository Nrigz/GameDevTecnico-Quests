using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graves3 : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public PlayerController script;
    public BossController scriptB;
    private int oldGraveCount;
    
    // Start is called before the first frame update
    void Start()
    {
        script = player.GetComponent<PlayerController>();
        scriptB = boss.GetComponent<BossController>();
        scriptB.speed += (float)script.gravesDestroyed;
        oldGraveCount = script.gravesDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldGraveCount != script.gravesDestroyed)
        {
            oldGraveCount = script.gravesDestroyed;
            scriptB.speed += (float)0.5;
        }
        if (script.gravesDestroyed == 5) 
        {
            script.isImmune = true;
            scriptB.canMove = false;
            scriptB.state = BossController.State.death;
            
        }
    }
}
