using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;
using static UnityEngine.InputSystem.InputAction;

public class playerManager : MonoBehaviour
{
    private PlayerControllerDog playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerControllerDog>();
    }
    public void OnMove(CallbackContext context)
    {
        playerController.SetInputVector(context.ReadValue<Vector2>());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
