using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDog : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float maxSpeed;
    private Rigidbody rb;
    Vector3 move;

    public float runTime;
    private float runTimerCounter;
    private bool isRunning;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool ground;
    private bool stoppedJumping;
    public LayerMask isGround;

    //public float gravityScale = 5;


    void Start()
    {
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }


        if (ground)
        {
            jumpTimeCounter = jumpTime;

            if ((Input.GetButtonDown("Jump")))
            {
                stoppedJumping = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isRunning = true;
                
            }
        }

        if (((Input.GetButton("Jump")) && !stoppedJumping))
        {
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
            } else stoppedJumping = true;
        }

        if ((Input.GetButtonUp("Jump")))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.velocity += new Vector3(move.x * speed, 0, 0);
        }
        if (Mathf.Abs(rb.velocity.z) < maxSpeed)
        {
            rb.velocity += new Vector3(0, 0, move.z * speed);
        }

        if (!stoppedJumping)
        {
            rb.velocity = (new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = false;
        }
    }
}   