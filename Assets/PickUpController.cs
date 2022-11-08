using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpController : MonoBehaviour
{
    private int coinNumber;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinNumber = 000;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinNumber++;
            coinText.text = coinNumber.ToString("000");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Flee")
        {
            collision.gameObject.GetComponent<FleeController>().agent.isStopped=true;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            Destroy(collision.gameObject, 2f);
        }
    }
}
