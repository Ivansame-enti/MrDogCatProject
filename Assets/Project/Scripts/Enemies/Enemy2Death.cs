using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerEnemy2")
        {
            this.transform.parent.gameObject.GetComponent<Enemy2Controller>().ropeCollision = true;
            Debug.Log("MUERE PERROOOO");
        }
    }
}
