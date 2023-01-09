using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyController : MonoBehaviour
{
    public Material mat;
    public bool hitbox1, hitbox2, hitbox3, hitbox4;
    private NavMeshAgent agent;
    private Transform player1, player2;
    public LayerMask groundMask, playerMask;

    public Vector3 walkPoint;
    bool hasRoute;
    public float walkingRange;

    public float attackRange;
    public float pushForce;
    bool playerInRange;
    public GameObject deathPS;

    private AudioManagerController audioSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        hitbox1 = false;
        hitbox2 = false;
        hitbox3 = false;
        hitbox4 = false;
        player1 = GameObject.FindGameObjectWithTag("Dog").transform;
        player2 = GameObject.FindGameObjectWithTag("Cat").transform;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInRange) FreeMove();
        else
        {
            //Debug.Log("In Range");
            AttackPlayer();
        }
        if (hitbox1) this.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material = mat;
        if (hitbox2) this.gameObject.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().material = mat;
        if (hitbox3) this.gameObject.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().material = mat;
        if (hitbox4) this.gameObject.transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().material = mat;
        if (hitbox1 && hitbox2 && hitbox3 && hitbox4)
        {
            audioSFX.AudioPlay("BasicEnemyDeath");
            Instantiate(deathPS, new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void FreeMove()
    {
        agent.speed = 3.0f;
        if (!hasRoute) calculateRandomPoint();
        else
        {
            agent.SetDestination(walkPoint);

            Vector3 distanceVector = this.transform.position - walkPoint;

            if (distanceVector.magnitude <= 1.0f) hasRoute = false;
        }

    }

    private void calculateRandomPoint()
    {
        float randomX = Random.Range(-walkingRange, walkingRange);
        float randomZ = Random.Range(-walkingRange, walkingRange);
        walkPoint = new Vector3(this.transform.position.x + randomX, this.transform.position.y, this.transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) hasRoute = true;
    }

    private void AttackPlayer()
    {
        agent.speed = 6.0f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Cat")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            //Debug.Log("asdasd");
            //collision.transform.position = direction;
            
            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
            //collision.transform.position += direction * 3;
        }
    }
}
