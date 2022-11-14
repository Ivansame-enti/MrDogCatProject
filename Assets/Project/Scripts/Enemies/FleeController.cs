using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public float movementSpeed;
    public bool flagActive;
    public float distanceLenght;
    private bool firstTime;
    private Rigidbody rb;
    public bool isPicked;
    // Start is called before the first frame update
    void Start()
    {
        isPicked = false;
        agent = this.GetComponent<NavMeshAgent>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        float distance = Vector3.Distance(this.transform.position, target.transform.position);

        if (distance < distanceLenght)
        {
            if (firstTime)
            {
                this.transform.LookAt(target.transform);
                //rb.velocity = (new Vector3(rb.velocity.x, 10000f, rb.velocity.z));
                firstTime = false;
            }
            //Vector3 vec = transform.position - target.transform.position;
            Vector3 dist = (target.transform.position - this.transform.position).normalized;

            //dist = Quaternion.AngleAxis(45, Vector3.up) * dist;
            Vector3 newPos = this.transform.position - (dist * movementSpeed);
            //Vector3 newPos = this.transform.position + vec;
            //newPos = vec.normalized;
            this.GetComponent<Animator>().SetInteger("Walk", 1);
            agent.SetDestination(newPos);
            //Debug.Log(newPos);
        }
        else
        {
            this.GetComponent<Animator>().SetInteger("Walk", 0);
            firstTime = true;
        }
    }
}
