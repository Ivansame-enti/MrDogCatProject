using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool checkpoint;

    private void Start()
    {
        checkpoint = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Dog" || collision.gameObject.tag == "Cat")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Sit", true);
            checkpoint = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Cat")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Sit", false);
            checkpoint = false;
        }
    }
}
