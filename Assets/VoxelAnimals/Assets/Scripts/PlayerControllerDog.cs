using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDog : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float maxSpeed;
    private Rigidbody rb;
    Vector3 move;

    public float runMin;
    private float runMinAux;
    public float runMax;
    public float runTime;
    private float runTimerCounter;
    private bool isRunning;

    public GameObject runningPS;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool ground;
    private bool stoppedJumping;
    public LayerMask isGround;

    public bool xboxController;

    //public float gravityScale = 5;


    void Start()
    {
        runMinAux = runMin;
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (xboxController)
        {
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
                anim.SetInteger("Walk", 1);
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }


            if (ground)
            {
                jumpTimeCounter = jumpTime;

                if ((Input.GetButtonDown("LB")))
                {
                    stoppedJumping = false;
                }

                if (Input.GetButton("LT"))
                {

                    isRunning = true;

                    if (runTimerCounter <= 0)
                    {
                        runningPS.SetActive(true);
                        runMin = runMax;
                    }
                    else
                    {
                        runTimerCounter -= Time.deltaTime;
                        runMin += Time.deltaTime;
                    }
                }
            }
            else if (isRunning)
            {
                //runningPS.SetActive(false);
            }

            if (((Input.GetButton("LB")) && !stoppedJumping))
            {
                if (jumpTimeCounter > 0)
                {
                    jumpTimeCounter -= Time.deltaTime;
                }
                else stoppedJumping = true;
            }

            if ((Input.GetButtonUp("LB")))
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (Input.GetButtonUp("LT"))
            {
                isRunning = false;
                runningPS.SetActive(false);
                runTimerCounter = runTime;
                runMin = runMinAux;
            }
        } else
        {
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
                anim.SetInteger("Walk", 1);
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }


            if (ground)
            {
                jumpTimeCounter = jumpTime;

                if ((Input.GetButtonDown("L1")))
                {
                    stoppedJumping = false;
                }

                if (Input.GetButton("L2"))
                {

                    isRunning = true;

                    if (runTimerCounter <= 0)
                    {
                        runningPS.SetActive(true);
                        runMin = runMax;
                    }
                    else
                    {
                        runTimerCounter -= Time.deltaTime;
                        runMin += Time.deltaTime;
                    }
                }
            }
            else if (isRunning)
            {
                //Hacer que cuando salte vuelva asu velocidad normal???
            }

            if (((Input.GetButton("L1")) && !stoppedJumping))
            {
                if (jumpTimeCounter > 0)
                {
                    jumpTimeCounter -= Time.deltaTime;
                }
                else stoppedJumping = true;
            }

            if ((Input.GetButtonUp("L1")))
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if ((Input.GetButtonUp("L2")))
            {
                isRunning = false;
                runningPS.SetActive(false);
                runTimerCounter = runTime;
                runMin = runMinAux;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isRunning)
        {
            if (Mathf.Abs(rb.velocity.x) < maxSpeed)
            {
                rb.velocity += new Vector3(move.x * speed, 0, 0);
            }
            if (Mathf.Abs(rb.velocity.z) < maxSpeed)
            {
                rb.velocity += new Vector3(0, 0, move.z * speed);
            }
        } else
        {
            if (Mathf.Abs(rb.velocity.x) < runMin)
            {
                rb.velocity += new Vector3(move.x * runMin, 0, 0);
            }
            if (Mathf.Abs(rb.velocity.z) < runMin)
            {
                rb.velocity += new Vector3(0, 0, move.z * runMin);
            }
        }


        if (!stoppedJumping)
        {
            rb.velocity = (new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = false;
        }
    }
}   