using UnityEngine;

public class atachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject originalPadre;
    private bool startea = false;
    private bool gatofuera = false;
    private bool perrofuera = false;
    public float timer;
    public float cooldown;


    private void Start()
    {
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1)
        {
            player1.transform.parent = transform;
            //gatofuera = false;
            //timer = cooldown;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = transform;
            //perrofuera = false;
            //timer = cooldown;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1.transform.parent = null;
            player1.transform.parent = originalPadre.transform;
            player1.transform.localScale = new Vector3(1, 1, 1);
            //gatofuera = true;
        }
        if (other.gameObject == player2)
        {
            player2.transform.parent = null;
            player2.transform.parent = originalPadre.transform;
            player2.transform.localScale = new Vector3(1,1,1);
            //perrofuera = true;
        }
    }



    private void Update()
    {
        if(player1.transform.parent == cube1.transform && player2.transform.parent == cube2.transform)// CADA UNO EN UNO DISTINTO perro izquierda gato derecha
        {
            startea = true;
            this.GetComponent<Animator>().SetBool("Move", true);

            /*if (player1.transform.parent == cube1.transform || player1.transform.parent == cube2.transform)
            {
                this.GetComponent<Animator>().SetBool("Move", true);
            }


            if (player2.transform.parent == cube1.transform || player2.transform.parent == cube2.transform)
            {
                this.GetComponent<Animator>().SetBool("Move", true);
            }*/
        }

        if (startea)
        {
            if (this.transform.childCount <= 0)
            {
                if (timer > cooldown)
                {
                    this.GetComponent<Animator>().SetBool("Move", false);
                }
                else timer += Time.deltaTime;
            }
            else timer = 0;
        }
        /*if (startea == true) { 
            if (player1.transform.parent == originalPadre.transform && player2.transform.parent == originalPadre.transform)
            {
                startea = false;
            }
        }*/
        /*else if(startea == false)
        {
            if (timer <= 0.0f) { 
                this.GetComponent<Animator>().SetBool("Move", false);
                timer = cooldown;
            } else timer -= Time.deltaTime;
            // player1.transform.parent = originalPadre.transform;
            // player2.transform.parent = originalPadre.transform;
        }
        else
        {
            timer = cooldown;
        }*/


      
    }
}
