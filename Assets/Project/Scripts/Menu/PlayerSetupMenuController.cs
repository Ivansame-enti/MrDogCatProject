using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int PlayerIndex;

    private int index;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject hatPanel;
    [SerializeField]
    private Button readyButton;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        //titleText.SetText("Player " + (pi+1).ToString());
        ignoreInputTime = Time.deltaTime + ignoreInputTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SetPrefab(int hat)
    {
        if (!inputEnabled) { return; }
        StaticClass.hatPicked = hat;
        readyPanel.SetActive(true);
        readyButton.Select();
        hatPanel.SetActive(false);
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }
}
