using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Dog" || collision.gameObject.tag == "Cat")
        {
            GameObject.FindGameObjectWithTag("Dog").GetComponent<RespawnController>().checkpoint = this.transform.position;
            GameObject.FindGameObjectWithTag("Cat").GetComponent<RespawnController>().checkpoint = this.transform.position;
        }
    }
}
