using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target1, target2;
    public Vector3 offset;
    Vector3 midpoint;
    // Start is called before the first frame update
    void Start()
    {
        midpoint = (target1.position + target2.position) / 2f;
        offset = midpoint - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        midpoint = (target1.position + target2.position) / 2f;
        transform.position = target2.position - offset;
    }
}
