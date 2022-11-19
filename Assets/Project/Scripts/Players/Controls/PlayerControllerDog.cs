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
    public float speed;
    public float maxSpeed;

    private Rigidbody rb;
    Vector3 move;

    public float runMin;
    private float runMinAux;
    public float runMax;
    public float runTime;
    private float runTimerCounter;
    private bool isRunning,pressRun,isJumping,isBarking, stoppedJumping, isPooping;
    private bool ground;
    public GameObject runningPS;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    Vector2 moveUniversal;
    public LayerMask isGround;
    private AudioManagerController audioSFX;

    [SerializeField]
    private int playerIndex = 0;

    public GameObject poopPrefab;
    private float timerPoop;
    public float jetTime;

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        runMinAux = runMin;
        runTimerCounter = runTime;
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
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
        move = new Vector3(moveUniversal.x, 0, moveUniversal.y);
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
        if(isRunning == false)
        {
            if(playerIndex == 0)
            {
                audioSFX.AudioStop("RunningDog");
            }
            if (playerIndex == 1)
            {
                audioSFX.AudioStop("RunningCat");
            }
            runningPS.SetActive(false);
            runTimerCounter = runTime;
            runMin = runMinAux;
        }
        if(isJumping == true)
        {
            stoppedJumping = false;

        }
        else if(isJumping == false)
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        if (isPooping == true)
        {
            if (playerIndex == 0)
            {
                if (timerPoop <= jetTime)
                {
                    GameObject poop = Instantiate(poopPrefab, transform.position, Quaternion.identity) as GameObject;
                    Destroy(poop, 2);
                    timerPoop += Time.deltaTime;
                }
                //Debug.Log("cagando");

                else
                {
                    if (timerPoop > 0 && ground) timerPoop -= Time.deltaTime;
                }
            }
        }
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
        if (ground)
        {
            if (isJumping == true)
            {
                if (!audioSFX.GetAudioPlaying("Jump"))
                {
                    audioSFX.ChangePitch("Jump", UnityEngine.Random.Range(0.7f, 1.7f));
                    audioSFX.AudioPlay("Jump");
                }                    
            }
            jumpTimeCounter = jumpTime;
            if (isRunning == true)
            {
                if (runTimerCounter <= 0)
                {
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

