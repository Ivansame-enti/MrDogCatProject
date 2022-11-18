using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Restart")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
