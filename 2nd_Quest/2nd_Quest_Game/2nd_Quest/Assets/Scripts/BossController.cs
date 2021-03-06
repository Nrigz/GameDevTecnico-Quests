using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private float movVector;
    public float dist;
    public float jump;
    public float speed;
    public bool canMove=true;

    public GameObject VictoryUI;


    public enum State { idle, running, attack, death }
    public State state = State.idle;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask killer;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movVector = player.transform.position.x - transform.position.x;
            if (Mathf.Abs(movVector) > dist)
            {
                state = State.running;
                if (movVector < 0)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                }
            }
        }
        
        //AnimationState();
        //if (state == State.death) canMove = false;
        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove && coll.IsTouchingLayers(killer))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
            
    }

    private void VictoryBoss()
    {
        Time.timeScale = 0f;
        VictoryUI.SetActive(true);
    }
}
