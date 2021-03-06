using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int gravesDestroyed = 0;

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private bool movFlag;
    private bool jmpFlag;
    private bool jmpResetFlag;

    private bool canMove;
    public bool isImmune = false;

    private float wallJmpTime = 0.1f;
    private float jmpTime;
    //States
    private enum State { idle, running, jumping, falling, attack , death}
    private State state = State.idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask killer;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 30f;
    [SerializeField] private AudioSource swordSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource landingSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathScream;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        movFlag = false;
        jmpFlag = false;
        jmpResetFlag = false;

        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            handleInput();
            verifyWallJump();
            verifyDeath();
        }
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            hMovement();
            vMovement();
        }
        
        AnimationState();
        anim.SetInteger("state", (int)state);

    }

    private void hMovement()
    {
        if (movFlag)
        {
            float hDirection = Input.GetAxis("Horizontal");

            if (hDirection < 0)
            {
                
                rb.velocity = new Vector2(hDirection * speed, rb.velocity.y);
                transform.localScale = new Vector2(-1, 1);
            }

            else if (hDirection > 0)
            {
                rb.velocity = new Vector2(hDirection * speed, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);
            }

            movFlag = false;
        }  
    }

    private void vMovement()
    {
        
        if (jmpFlag)
        {
            jumpSound.Play();
            jmpResetFlag = false;
            rb.AddForce(new Vector2(0, jump));
            state = State.jumping;
            jmpFlag = false;
        }
        else if (jmpResetFlag)
        {
            jumpSound.Play();
            float hDirection = Input.GetAxis("Horizontal");
            if (hDirection > 0) rb.velocity = new Vector2(rb.velocity.x+20, 40);
            else rb.velocity = new Vector2(rb.velocity.x - 20, 40);
            jmpResetFlag = false;
            state = State.jumping;
        }
    }

    private void verifyWallJump()
    {
        if (coll.IsTouchingLayers(ground)) jmpTime = Time.time + wallJmpTime;
    }

    private void verifyDeath()
    {
        if (!isImmune && coll.IsTouchingLayers(killer))
        {
            canMove = false;
            deathScream.Play();
            deathSound.Play();
            state = State.death;
        }
    }
    private void handleInput()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (hDirection != 0) movFlag = true;

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)) 
        {
            if (hDirection == 0  || rb.velocity.x != 0) jmpFlag = true;
        }
        
        else if (Input.GetButtonDown("Jump") && jmpTime > Time.time) jmpResetFlag = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            
            if (Input.GetKey(KeyCode.F))
            {
                swordSound.Play();
                canMove = false;
                state = State.attack;
                Destroy(collision.gameObject);
                gravesDestroyed++;
            }
        }
    }

    private void Death()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void AnimationState()
    {
        if (state == State.death) ;
        else if (state == State.attack) ;

        else if (state == State.jumping)
        {
            if (rb.velocity.y < -0.1f)
            {
                state = State.falling;
            }
        }


        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                //landingSound.Play();
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 1.5f)
        {
            if (rb.velocity.y < -0.1f) state = State.falling;
            else state = State.running;
        }

        else
        {
            if (rb.velocity.y < -0.1f) state = State.falling;
            else state = State.idle;
        }
    }
    private void StoppedAttacK()
    {
        canMove = true;
        state = State.idle;
    }
}
