using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDog : MonoBehaviour
{
    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f,gravityScale;
    Animator anim;
    public Vector3 moveDirection;

    public float speed;
    public float maxSpeed;
    public Rigidbody rb;
    Vector3 move;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

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
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("LB") && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }

    }
    void ControllPlayer()
    {
        /*
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed,0,0));
            Debug.Log("entra aqui");
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, movementSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -movementSpeed));
        }
        */
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("LB") && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }
    }
}