using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    private Transform player1, player2;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Dog").transform;
        player2 = GameObject.Find("Cat").transform;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Animator>().SetInteger("Walk", 1);
        agent.speed = 3.0f;
        Vector3 distanceToPlayerOne = this.transform.position - player1.position;
        Vector3 distanceToPlayerTwo = this.transform.position - player2.position;

        if (distanceToPlayerOne.magnitude <= distanceToPlayerTwo.magnitude)
        {
            //transform.LookAt(player1);
            agent.SetDestination(player1.position);
        }
        else
        {
            //transform.LookAt(player2);
            agent.SetDestination(player2.position);
        }
    }
}
