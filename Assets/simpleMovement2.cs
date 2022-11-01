using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement2 : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public Rigidbody rb;
    Vector3 move;

    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += rb.velocity * 1.5f;
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
    }
}
