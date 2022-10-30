using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement2 : MonoBehaviour
{
    public float movementSpeed = 7;
    public float jumpForce = 1000;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        if (Input.GetKey(KeyCode.O) && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
        }

        if (Input.GetKey(KeyCode.J))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));

        }
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.I))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, movementSpeed));
        }
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -movementSpeed));
        }
    }
}
