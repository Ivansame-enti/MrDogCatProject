using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPrototipeTriggerEnter : MonoBehaviour
{
    public GameObject fences, enemy2;
    private bool firstTime;

    private void Start()
    {
        firstTime = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger" && firstTime)
        {
            fences.SetActive(true);
            firstTime = false;
        }
    }

    private void Update()
    {
        if (enemy2 == null) fences.SetActive(false);
    }
}
