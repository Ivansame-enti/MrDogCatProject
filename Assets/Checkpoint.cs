using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Dog" || collision.gameObject.tag == "Cat")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Sit", true);
            //GameObject.FindGameObjectWithTag("Dog").GetComponent<RespawnController>().checkpoint = this.transform.position;
            //GameObject.FindGameObjectWithTag("Cat").GetComponent<RespawnController>().checkpoint = this.transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Cat")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Sit", false);
            //GameObject.FindGameObjectWithTag("Dog").GetComponent<RespawnController>().checkpoint = this.transform.position;
            //GameObject.FindGameObjectWithTag("Cat").GetComponent<RespawnController>().checkpoint = this.transform.position;
        }
    }
}
