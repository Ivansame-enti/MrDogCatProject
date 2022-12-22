using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetupMenuPrefab,playerSetupMenuPrefab2;
    public PlayerInput input;
    private GameObject canvas;

    private void Awake()
    {
        var rootMenu = GameObject.Find("PlayerCanvas3");
        if(rootMenu != null)
        {
            if (input.playerIndex == 0)
            {
                var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
                input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
                menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(input.playerIndex);
            }
            if (input.playerIndex == 1)
            {
                var menu = Instantiate(playerSetupMenuPrefab2, rootMenu.transform);
                input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
                menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(input.playerIndex);
            }

        }
    }
}
