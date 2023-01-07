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
    public float speed;
    private float originalSpeed;
    public float maxSpeed;

    private Rigidbody rb;

    private Vector3 moveDirection;
    private float moveMagnitude;

    public float runMin;
    private float runMinAux;
    public float runMax;
    public float runTime;
    private float runTimerCounter;
    private bool isRunning, pressRun, isJumping, isBarking, stoppedJumping, isPooping;
    private bool ground;
    public GameObject runningPS;
    public GameObject runningPSLow1, runningPSLow2, runningPSLow3, runningPSLow4;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    Vector2 moveUniversal;
    public LayerMask isGround;
    private AudioManagerController audioSFX;
    private bool flagjump = true;
    public GameObject poopPrefab;
    private float timerPoop;
    public float jetTime;
    public GameObject runningDonutPS;
    private bool particlesOnlyOnce = true;


    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        runMinAux = runMin;
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        originalSpeed = speed;
    }
    public void SetInputVector(Vector2 direction)
    {
        moveUniversal = direction;
    }
    public void SetRunning(bool pressRun)
    {
        isRunning = pressRun;
    }
    public void SetJump(bool pressJump)
    {
        isJumping = pressJump;
        // anim.SetBool("jump", true);
    }
    public void SetBark(bool pressBarking)
    {
        isBarking = pressBarking;
    }
    public void SetPoop(bool pressPoop)
    {
        isPooping = pressPoop;
    }
    private void Update()
    {
        var cam = Camera.main;

        var camRight = cam.transform.right;
        var camForward = cam.transform.forward;

        camRight.y = 0;
        camForward.y = 0;

        camRight.Normalize();
        camForward.Normalize();

        moveDirection = camRight * moveUniversal.x + camForward * moveUniversal.y;
        moveDirection.Normalize();

        moveMagnitude = moveUniversal.magnitude;

        //Debug.Log($"Move Direction: {moveDirection}, Move Magnitude: {moveMagnitude}");

        if (moveMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
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

        if (isRunning == false)
        {
            //Debug.Log("dasds");
            if(this.gameObject.tag=="Dog") audioSFX.AudioStop("RunningDog");
            if(this.gameObject.tag=="Cat") audioSFX.AudioStop("RunningCat");
            runningPS.SetActive(false);
            runningPSLow1.SetActive(false);
            runningPSLow2.SetActive(false);
            runningPSLow3.SetActive(false);
            runningPSLow4.SetActive(false);
            particlesOnlyOnce = true;
            runTimerCounter = runTime;
            runMin = runMinAux;
        }

        if (isJumping == true)
        {
            if (flagjump == true)
            {
                anim.SetBool("jump", true);
                flagjump = false;
            }
            else
            {
                anim.SetBool("jump", false);
            }
            stoppedJumping = false;

        }
        else if (isJumping == false)
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;

        }
        /*
        if (isBarking == true)
        {
            if (playerIndex == 0)
            {
                if (!audioSFX.GetAudioPlaying("Bark"))
                    audioSFX.AudioPlay("Bark");
            }
            if (playerIndex == 1)
            {
                if (!audioSFX.GetAudioPlaying("Meow"))
                    audioSFX.AudioPlay("Meow");
            }
        }
        */
        if (ground)
        {
            flagjump = true;
            //speed = originalSpeed;
            if (isJumping == true)
            {
                //anim.SetBool("jump", true);

                //speed *= 2;
                if (!audioSFX.GetAudioPlaying("Jump"))
                {
                    audioSFX.ChangePitch("Jump", UnityEngine.Random.Range(0.7f, 1.7f));
                    audioSFX.AudioPlay("Jump");
                }
            }
            jumpTimeCounter = jumpTime;
            if (isRunning == true && moveMagnitude > Mathf.Epsilon)
            {
                if (runTimerCounter <= 0)
                {
                    if (!audioSFX.GetAudioPlaying("RunningCat") && this.gameObject.tag=="Cat")
                        audioSFX.AudioPlay("RunningCat");

                    if (!audioSFX.GetAudioPlaying("RunningDog") && this.gameObject.tag == "Dog")
                        audioSFX.AudioPlay("RunningDog");
                    /*
                    if (playerIndex == 0)
                    {
                        if (!audioSFX.GetAudioPlaying("RunningDog"))
                            audioSFX.AudioPlay("RunningDog");
                    }
                    if (playerIndex == 1)
                    {
                        if (!audioSFX.GetAudioPlaying("RunningCat"))
                            audioSFX.AudioPlay("RunningCat");
                    }
                    */
                    runningPSLow1.SetActive(false);
                    runningPSLow2.SetActive(false);
                    runningPSLow3.SetActive(false);
                    runningPSLow4.SetActive(false);
                    if (particlesOnlyOnce)
                    {
                        Instantiate(runningDonutPS, new Vector3(this.transform.position.x, this.transform.position.y + 2.0f, this.transform.position.z), this.transform.rotation);
                        particlesOnlyOnce = false;
                    }
                    runningPS.SetActive(true);
                    runMin = runMax;

                }
                else
                {
                    runningPSLow1.SetActive(true);
                    runningPSLow2.SetActive(true);
                    runningPSLow3.SetActive(true);
                    runningPSLow4.SetActive(true);
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

        var targetMove = moveDirection * moveMagnitude;
        if (!isRunning)
        {
            if (Mathf.Abs(rb.velocity.x) < maxSpeed && moveMagnitude > Mathf.Epsilon)
            {
                //Debug.Log("aaa");
                rb.velocity += new Vector3(targetMove.x * speed, 0, 0);
            }
            if (Mathf.Abs(rb.velocity.z) < maxSpeed && moveMagnitude > Mathf.Epsilon)
            {
                //Debug.Log("aaa");
                rb.velocity += new Vector3(0, 0, targetMove.z * speed);
            }
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) < runMin && moveMagnitude > Mathf.Epsilon)
            {
                rb.velocity += new Vector3(targetMove.x * runMin, 0, 0);
            }
            if (Mathf.Abs(rb.velocity.z) < runMin && moveMagnitude > Mathf.Epsilon)
            {
                rb.velocity += new Vector3(0, 0, targetMove.z * runMin);
            }
        }
        if (!stoppedJumping)
        {
            rb.velocity = (new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
            //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            //rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
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

