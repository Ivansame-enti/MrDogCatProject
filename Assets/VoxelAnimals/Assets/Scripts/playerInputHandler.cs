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
    private PlayerControllerDog mover;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<PlayerControllerDog>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }
    public void OnMove(CallbackContext context)
    {
        if(mover != null)
        {
            mover.SetInputVector(context.ReadValue<Vector2>());

        }
    }
}
