using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFloorCollision : MonoBehaviour
{
    public bool detectPlayer;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cat" || collision.gameObject.tag == "Dog")
        {
            detectPlayer = true;
            animator.enabled = true;
        }
    }
}
