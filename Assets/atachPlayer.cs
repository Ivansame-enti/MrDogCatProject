using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;

    private Animation anim;



    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["spin"].layer = 123;
        anim.Stop("MovePlatform");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1)
        {
            player1.transform.parent = transform;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1.transform.parent = null;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = null;
        }
    }



    private void Update()
    {
        if(player1.transform.parent==this && player2.transform.parent == this)
        {

            anim.Play("MovePlatform");
        }
    }
}
