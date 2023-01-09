using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class playerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerControllerDog playerController;
    private Controls controls;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerControllerDog>();
        controls = new Controls();
    }
    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if(obj.action.name == controls.Dog.Movement.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.Dog.Run.name)
        {
            OnRun(obj);
        }
        if (obj.action.name == controls.Dog.Jump.name)
        {
            OnJump(obj);
        }
        if(obj.action.name == controls.Dog.Pause.name)
        {
            OnPause(obj);
        }
    }

    public void OnMove(CallbackContext context)
    {
        if(playerController != null)
            playerController.SetInputVector(context.ReadValue<Vector2>());
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.SetRunning(context.ReadValueAsButton());
        
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.SetJump(context.ReadValueAsButton()); 
    }
    public void OnBark(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.SetBark(context.ReadValueAsButton());
    }
    public void OnPoop(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.SetPoop(context.ReadValueAsButton());
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.SetPause(context.ReadValueAsButton());
    }
}
