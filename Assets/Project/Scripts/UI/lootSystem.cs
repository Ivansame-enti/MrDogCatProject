using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemToSpawn
{
   // public GameObject[] ComunHat;
    public GameObject[] item;
    public float spawRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;

}

public class lootSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemToSpawn[] itemToSpawn;
 
    void Start()
    {

        for (int i=0; i<itemToSpawn.Length;i++)
        {
            if (i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawRate - 1;  

            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawRate - 1;
            }

        }

       Spawner();

    }

    void Update()
    {

     //   if (Input.GetKeyDown(KeyCode.E))
      //  {
       //     Spawner();
     //   }



    }

    void Spawner()
    {
        float randomNum = Random.Range(0, 100);
        int randomNum2 = 0;
        for (int i=0; i<itemToSpawn.Length; i++)
        {

            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {

               
                if (i == 0)
                {
                    Debug.Log("Comun");
                   randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    Debug.Log(randomNum2);
                    GameObject hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i==1)
                {
                    Debug.Log("Poco Comun");
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    GameObject hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 2)
                {
                    Debug.Log("Rara");
                    GameObject hat = Instantiate(itemToSpawn[i].item[0], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 3)
                {
                    Debug.Log("EPICA DORADA");
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    GameObject hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 4)
                {
                    Debug.Log("WOOOOOOW LEGENDARIAAAAAAAAAAAA");
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    GameObject hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                }

                break;
            }

        }

    }

}
