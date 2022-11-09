using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    //public InputAction dogController;
    Vector2 moveUniversal;
    //public float gravityScale = 5;
    Controls catControls;

    private void Awake()
    {
        catControls = new Controls();
        catControls.Cat.Run.performed += ctx => Run();
        catControls.Cat.Run.canceled += ctx => dontRun();
        catControls.Cat.Movement.performed += ctx => moveUniversal = ctx.ReadValue<Vector2>();
        catControls.Cat.Movement.canceled += ctx => moveUniversal = Vector2.zero;
        catControls.Cat.Jump.performed += ctx => Jump();
        catControls.Cat.Jump.canceled += ctx => StopJump();
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
        catControls.Enable();
        //dogController.Enable();
    }

    private void OnDisable()
    {
        catControls.Disable();
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
    private void Update()
    {

        //moveUniversal = dogController.ReadValue<Vector2>();
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