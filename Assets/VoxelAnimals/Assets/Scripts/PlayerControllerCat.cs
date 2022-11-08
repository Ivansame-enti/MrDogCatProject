using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCat : MonoBehaviour
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

    void Start()
    {
        runMinAux = runMin;
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (xboxController)
        {
            move = new Vector3(Input.GetAxisRaw("HorizontalRightXbox"), 0, Input.GetAxisRaw("VerticalRightXbox"));

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
                if(!isRunning) anim.SetInteger("Walk", 1);
                else anim.SetInteger("Walk", 2);
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }

            if (ground)
            {
                jumpTimeCounter = jumpTime;

                if ((Input.GetButtonDown("RB")))
                {
                    stoppedJumping = false;
                }

                if (Input.GetButton("RT"))
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

            if (((Input.GetButton("RB")) && !stoppedJumping))
            {
                if (jumpTimeCounter > 0)
                {
                    jumpTimeCounter -= Time.deltaTime;
                }
                else stoppedJumping = true;
            }

            if ((Input.GetButtonUp("RB")))
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (Input.GetButtonUp("RT"))
            {
                isRunning = false;
                runningPS.SetActive(false);
                runTimerCounter = runTime;
                runMin = runMinAux;
            }
        } else //Mando ps4
        {
            move = new Vector3(Input.GetAxisRaw("HorizontalRightPlay"), 0, Input.GetAxisRaw("VerticalRightPlay"));

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
                if (!isRunning) anim.SetInteger("Walk", 1);
                else
                {
                    anim.SetInteger("Walk", 2);
                }
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }

            if (ground)
            {
                jumpTimeCounter = jumpTime;

                if ((Input.GetButtonDown("R1")))
                {
                    stoppedJumping = false;
                }

                if (Input.GetButton("R2"))
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

            if (((Input.GetButton("R1")) && !stoppedJumping))
            {
                if (jumpTimeCounter > 0)
                {
                    jumpTimeCounter -= Time.deltaTime;
                }
                else stoppedJumping = true;
            }

            if ((Input.GetButtonUp("R1")))
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (Input.GetButtonUp("R2"))
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
        }
        else
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
            //Debug.Log("ola");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((isGround.value & (1 << collision.gameObject.layer)) > 0)
        {
            ground = false;
            //Debug.Log("adios");
        }
    }
}