using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimAnimals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool("WinAnim", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
