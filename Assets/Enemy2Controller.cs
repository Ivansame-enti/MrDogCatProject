using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    private Transform player1, player2;
    private bool move=true;
    //private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Dog").transform;
        player2 = GameObject.Find("Cat").transform;
        //agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            this.GetComponent<Animator>().SetInteger("Walk", 1);
            //agent.speed = 3.0f;
            Vector3 distanceToPlayerOne = this.transform.position - player1.position;
            Vector3 distanceToPlayerTwo = this.transform.position - player2.position;

            if (distanceToPlayerOne.magnitude <= distanceToPlayerTwo.magnitude)
            {
                //transform.LookAt(player1);
                //agent.SetDestination(player1.position);
                //Quaternion targetRotation = Quaternion.LookRotation(player1.position - transform.position);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, targetRotation.y, targetRotation.z, targetRotation.w), 100 * Time.deltaTime);

                var lookDir = player1.position - transform.position;
                lookDir.y = 0; // keep only the horizontal direction
                               //transform.rotation = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player1.position, 20 * Time.deltaTime);
            }
            else
            {
                //transform.LookAt(player2);
                //agent.SetDestination(player2.position);
                var lookDir = player2.position - transform.position;
                lookDir.y = 0; // keep only the horizontal direction
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player2.position, 20 * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
        }
    }
}
