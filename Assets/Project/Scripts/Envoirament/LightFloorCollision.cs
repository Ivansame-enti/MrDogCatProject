using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFloorCollision : MonoBehaviour
{
    public bool detectPlayer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cat" || collision.gameObject.tag == "Dog")
        {
            detectPlayer = true;
        }
    }
}
