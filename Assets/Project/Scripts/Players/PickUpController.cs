using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpController : MonoBehaviour
{
    private int objective1Number, objective2Number;
    public TextMeshProUGUI coinText;
    public int coinNumber;
    private AudioManagerController audioSFX;
    private void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        coinNumber = 000;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinNumber++;
            coinText.text = coinNumber.ToString("000");
            audioSFX.AudioPlay("Coin");
        }
    }
}
