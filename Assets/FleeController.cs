using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeController : MonoBehaviour
{
    public GameObject target;
    public float movementSpeed;
    public bool flagActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flagActive)
        {
            Vector3 dir = transform.position - target.transform.position;
            transform.Translate(dir * movementSpeed * Time.deltaTime);
        }
    }
}
