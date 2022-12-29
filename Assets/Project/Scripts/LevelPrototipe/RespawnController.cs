using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public string sceneName;
    public Vector3 checkpoint;
    private GameObject dog, cat;

    private void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        cat = GameObject.FindGameObjectWithTag("Cat");
        checkpoint = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Restart")
        {
            dog.transform.position = dog.GetComponent<RespawnController>().checkpoint;
            cat.transform.position = cat.GetComponent<RespawnController>().checkpoint;
        }
    }
}
