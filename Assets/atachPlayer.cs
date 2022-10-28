using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
