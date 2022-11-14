using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    private Transform player1, player2;
    private bool move=true;
    public float speed;
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
            Vector3 distanceToPlayerOne = this.transform.position - player1.position;
            Vector3 distanceToPlayerTwo = this.transform.position - player2.position;

            if (distanceToPlayerOne.magnitude <= distanceToPlayerTwo.magnitude)
            {
                var lookDir = player1.position - transform.position;
                lookDir.y = 0;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player1.position, 20 * Time.deltaTime);
            }
            else
            {
                var lookDir = player2.position - transform.position;
                lookDir.y = 0;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, player2.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().mass = 50;
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
            //this.GetComponent<Rigidbody>().AddForce(-direction * 100, ForceMode.Impulse);
            move = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().mass = 0.1f;
            //move = true;
        }
    }
}
