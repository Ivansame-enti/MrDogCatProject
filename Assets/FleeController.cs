using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeController : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    public float movementSpeed;
    public bool flagActive;
    public float distanceLenght;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
            float distance = Vector3.Distance(this.transform.position, target.transform.position);

            if (distance < distanceLenght)
            {
            //Vector3 vec = transform.position - target.transform.position;
            Vector3 dist = (target.transform.position - this.transform.position).normalized;

            //dist = Quaternion.AngleAxis(45, Vector3.up) * dist;
            Vector3 newPos = this.transform.position - (dist * movementSpeed);
            //Vector3 newPos = this.transform.position + vec;
            //newPos = vec.normalized;
            this.GetComponent<Animator>().SetInteger("Walk",1);
            agent.SetDestination(newPos);
            } else this.GetComponent<Animator>().SetInteger("Walk", 0);
    }
}
