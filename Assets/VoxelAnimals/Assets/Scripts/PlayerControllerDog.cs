using EasyPolyMap.Core;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControllerDog : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    public float speed;

    [SerializeField]
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


    Vector2 moveUniversal;

    Controls dogControls;

    [SerializeField]
    private int playerIndex = 0;

    private void Awake()
    {

        dogControls = new Controls();
        //dogControls.Dog.Run.performed += ctx => Run();
        //dogControls.Dog.Run.canceled += ctx => dontRun();
        //dogControls.Dog.Movement.performed += ctx => moveUniversal = ctx.ReadValue<Vector2>();
        //dogControls.Dog.Movement.canceled += ctx => moveUniversal = Vector2.zero;
        //dogControls.Dog.Jump.performed += ctx => Jump();
        //dogControls.Dog.Jump.canceled += ctx => StopJump();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    void Jump()
    {
        stoppedJumping = false;
       
    }
    void StopJump()
    {
        jumpTimeCounter = 0;
        stoppedJumping = true;

    }
    void Run()
    {
        isRunning = true;


    }
    void dontRun()
    {
        isRunning = false;
        runningPS.SetActive(false);
        runTimerCounter = runTime;
        runMin = runMinAux;
        
    }

    private void OnEnable()
    {
        dogControls.Enable();
        //dogController.Enable();
    }

    private void OnDisable()
    {
        dogControls.Disable();
        //dogController.Disable();
    }
    void Start()
    {
        runMinAux = runMin;
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }
    public void OnMove(CallbackContext context)
    {
        moveUniversal = context.ReadValue<Vector2>();
        move = new Vector3(moveUniversal.x, 0, moveUniversal.y);
    }
    public void SetInputVector(Vector2 direction)
    {
        moveUniversal = direction;
    }

    public void SetRunning(bool run = true)
    {
        isRunning = run;
    }
    private void Update()
    {
        move = new Vector3(moveUniversal.x, 0, moveUniversal.y);
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
            if (isRunning == true)
            {
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
        if ((!stoppedJumping))
        {
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
            }
            else stoppedJumping = true;
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


/*
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
*/