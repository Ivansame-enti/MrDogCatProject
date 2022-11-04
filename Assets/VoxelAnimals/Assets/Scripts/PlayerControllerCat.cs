using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCat : MonoBehaviour
{
    Animator anim;

    public float speed;
    public float maxSpeed;
    private Rigidbody rb;
    Vector3 move;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool ground;
    private bool stoppedJumping;
    public LayerMask isGround;

    void Start()
    {
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));

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

            if ((Input.GetButtonDown("Jump2")))
            {
                stoppedJumping = false;
            }
        }

        if (((Input.GetButton("Jump2")) && !stoppedJumping))
        {
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
            }
            else stoppedJumping = true;
        }

        if ((Input.GetButtonUp("Jump2")))
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
            //Debug.Log("ola");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = false;
            //Debug.Log("adios");
        }
    }
}