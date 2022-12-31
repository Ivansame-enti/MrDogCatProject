using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public GameObject bed1, bed2;
    private Checkpoint ch1, ch2;
    private bool onlyOnce;
    public GameObject checkPointPS;
    // Start is called before the first frame update
    void Start()
    {
        ch1 = bed1.GetComponent<Checkpoint>();
        ch2 = bed2.GetComponent<Checkpoint>();
        onlyOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ch1.checkpoint && ch2.checkpoint && onlyOnce)
        {
            Invoke("InstantiateParticles", 2.0f);    
            onlyOnce = false;
        }    
    }

    void InstantiateParticles()
    {
        Instantiate(checkPointPS, new Vector3(bed1.transform.position.x, bed1.transform.position.y + 5.0f, bed1.transform.position.z), Quaternion.identity);
        Instantiate(checkPointPS, new Vector3(bed2.transform.position.x, bed2.transform.position.y + 5.0f, bed2.transform.position.z), Quaternion.identity);
    }
}
