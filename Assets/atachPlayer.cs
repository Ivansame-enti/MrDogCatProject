using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public GameObject cube1;
    public GameObject cube2;
 



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1)
        {
            player1.transform.parent = transform;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1.transform.parent = null;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = null;
        }
    }



    private void Update()
    {
        if(player1.transform.parent == cube1 && player2.transform.parent == cube2)//CADA UNO EN UNO DISTINTO perro izquierda gato derecha
        {
            Debug.Log("entra");
            this.GetComponent<Animator>().SetBool("Move", true);
          
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Move", false);
        }
    }
}
