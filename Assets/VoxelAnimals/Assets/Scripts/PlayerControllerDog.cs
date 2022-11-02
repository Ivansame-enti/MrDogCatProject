using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDog : MonoBehaviour
{
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f,gravityScale;
    Animator anim;
    public Vector3 moveDirection;

    public float speed;
    public float maxSpeed;
    public Rigidbody rb;
    Vector3 move;

    public float forceJump;
    public bool ground;
    float jump;
    private bool jumpFlag;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += rb.velocity * 1.5f;
        }*/


        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        if ((ground == true) && (Input.GetButtonDown("Jump")))
        {
            jumpFlag = true;
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

        if (jumpFlag)
        {
            rb.velocity = (new Vector3(rb.velocity.x, forceJump, rb.velocity.z));
            jumpFlag = false;
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
            //Debug.Log("ola");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
            //Debug.Log("adios");
        }
    }
}   