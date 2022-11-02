using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCat : MonoBehaviour
{
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;


    public Vector3 moveDirection;

    public float speed;
    public float maxSpeed;
    Vector3 move;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += rb.velocity * 1.5f;
        }


        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
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
        if (Input.GetButtonDown("Jump2") || Input.GetButtonDown("RB") && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
    }
}