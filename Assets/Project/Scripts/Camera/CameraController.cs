using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target1, target2;
    public Vector3 offset;
    Vector3 midpoint;
    // Start is called before the first frame update
    void Start()
    {
        target1 = GameObject.FindGameObjectWithTag("Dog").transform;
        target2 = GameObject.FindGameObjectWithTag("Cat").transform;
        midpoint = (target1.position + target2.position) / 2f;
        offset = midpoint - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        midpoint = (target1.position + target2.position) / 2f;
        transform.position = midpoint - offset;
    }
}
