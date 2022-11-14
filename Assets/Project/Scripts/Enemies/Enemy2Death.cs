using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Death : MonoBehaviour
{
    //public BoxCollider bc;

    private void Start()
    {

    }
    private void  OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("eiii");
            Destroy(this.transform.parent.gameObject);
        }
    }
}
