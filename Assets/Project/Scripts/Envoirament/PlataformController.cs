using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    private Vector3 startPos, endPos;
    [SerializeField]
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + direction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.Lerp(startPos,endPos,Time.deltaTime);
    }
}
