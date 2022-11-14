using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeCollider : MonoBehaviour
{
    public GameObject bunny, mouse;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flee")
        {
            bunny.GetComponent<FleeController>().flagActive = true;
            mouse.GetComponent<FleeController>().flagActive = true;
        }
    }
}
