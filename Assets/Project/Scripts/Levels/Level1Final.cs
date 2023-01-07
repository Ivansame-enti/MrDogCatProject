using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Final : MonoBehaviour
{
    public GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag.transform.position.y >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
