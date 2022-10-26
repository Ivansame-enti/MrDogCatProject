using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementController : MonoBehaviour
{
    public float _speed = 1;
    private Vector3 vel = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;

        vel.y = this.GetComponent<Rigidbody>().velocity.y;
        this.GetComponent<Rigidbody>().velocity = vel;
    }
}
