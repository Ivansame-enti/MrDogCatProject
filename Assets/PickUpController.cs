using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpController : MonoBehaviour
{
    private int coinNumber, objective1Number, objective2Number;
    public TextMeshProUGUI coinText, objective1Text, objective2Text;

    private void Start()
    {
        coinNumber = 000;
        objective1Number = 0;
        objective2Number = 0;

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
            if (!collision.gameObject.GetComponent<FleeController>().isPicked)
            {
                collision.gameObject.GetComponent<FleeController>().isPicked = true;
                collision.gameObject.GetComponent<FleeController>().agent.isStopped = true;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
                objective2Number++;
                objective2Text.text = objective2Number.ToString();
                coinNumber+=7;
                coinText.text = coinNumber.ToString("000");
                Destroy(collision.gameObject, 2f);
            }
        }

        if (collision.gameObject.tag == "Flee2")
        {
            if (!collision.gameObject.GetComponent<FleeController>().isPicked)
            {
                collision.gameObject.GetComponent<FleeController>().isPicked = true;
                collision.gameObject.GetComponent<FleeController>().agent.isStopped = true;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
                objective1Number++;
                objective1Text.text = objective1Number.ToString();
                coinNumber += 7;
                coinText.text = coinNumber.ToString("000");
                Destroy(collision.gameObject, 2f);
            }
        }
    }
}
