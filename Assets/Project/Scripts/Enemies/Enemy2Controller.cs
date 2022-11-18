using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    public bool ropeCollision;
    private Transform player1, player2;
    private bool move;
    public float speed;
    private float timer;
    private float timer2;
    public float timeBettwenAttacks;
    public float attackRange;
    bool playerInRange;
    public LayerMask playerMask;
    private bool checkedPlayer;
    private Vector3 playerPos;
    public float chargeTime;
    private AudioManagerController audioSFX;
    private AudioSource audioSource;
    public GameObject deathPS;
    //private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        audioSource = GetComponent<AudioSource>();
        ropeCollision = false;
        move = false;
        timer2 = 0;
        timer = timeBettwenAttacks;
        player1 = GameObject.Find("Dog").transform;
        player2 = GameObject.Find("Cat").transform;
        //agent = this.GetComponent<NavMeshAgent>();
        checkedPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (playerInRange) //Mira si el jugador esta  a rango
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            if (!ropeCollision)
            {
                //Debug.Log("entra");
                if (timer >= timeBettwenAttacks) //Si ha pasado el tiempo de buscar
                {
                    if (!checkedPlayer) //Cogemos la posicion actual del jugador mas cercano e inicializamos el timer 2
                    {
                        Vector3 distanceToPlayerOne = this.transform.position - player1.position;
                        Vector3 distanceToPlayerTwo = this.transform.position - player2.position;

                        if (distanceToPlayerOne.magnitude <= distanceToPlayerTwo.magnitude)
                        {
                            playerPos = player1.position;
                            //var lookDir = player1.position - transform.position;
                            //lookDir.y = 0;
                            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                            //transform.position = Vector3.MoveTowards(transform.position, player1.position, 20 * Time.deltaTime);
                        }
                        else
                        {
                            playerPos = player2.position;
                            //var lookDir = player2.position - transform.position;
                            //lookDir.y = 0;
                            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                            //transform.position = Vector3.MoveTowards(transform.position, player2.position, speed * Time.deltaTime);
                        }
                        timer2 = chargeTime;
                        checkedPlayer = true;
                    }
                }
                else //Si esta en CD, se queda en estado Idle
                {
                    this.GetComponent<Animator>().SetInteger("Walk", 0);
                    timer += Time.deltaTime;
                    audioSource.Stop();
                }

                if (timer2 <= 0 && checkedPlayer) //Si el tiempo de carga ha terminado y hay un objetivo, hace la carga
                {
                    move = true;
                    var lookDir = playerPos - transform.position;
                    lookDir.y = 0;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards(transform.position, playerPos, 20 * Time.deltaTime);

                    if (Vector3.Distance(transform.position, playerPos) <= 1) //Si ha llegado al destino se queda en CD
                    {
                        checkedPlayer = false;
                        timer = 0;
                        move = false;
                        //audioSource.Stop();
                    }
                }
                else if (checkedPlayer)
                {
                    var lookDir = playerPos - transform.position;
                    lookDir.y = 0;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDir), 100 * Time.deltaTime);
                    this.GetComponent<Animator>().SetInteger("Walk", 1);
                    audioSource.Play();
                    timer2 -= Time.deltaTime;
                }
            }
            else
            {
                Invoke("InvokeParticles", 1.5f);
                audioSource.Stop();
                audioSFX.AudioPlay("ChickenDeath");
                Destroy(this.gameObject, 2.0f);
            }
        }
        else this.GetComponent<Rigidbody>().isKinematic = true;
        /*
        if (timer>=timeBettwenAttacks)
        {
            this.GetComponent<Animator>().SetInteger("Walk", 1);
            Vector3 distanceToPlayerOne = this.transform.position - player1.position;
            Vector3 distanceToPlayerTwo = this.transform.position - player2.position;
            move = true;
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
            timer = 0;
        }
        else timer += Time.deltaTime;*/
    }

    private void InvokeParticles()
    {
        Instantiate(deathPS, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().mass = 100;
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().mass = 0.3f;
        }
    }


}
