using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class playerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerControllerDog playerController;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        
        var movers = FindObjectsOfType<PlayerControllerDog>();
        
        var index = playerInput.playerIndex;
        playerController = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
        Debug.Log(index);
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
}
