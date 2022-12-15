using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemToSpawn
{
    public GameObject item;
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

        for (int i=0; i<itemToSpawn.Length; i++)
        {
            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {

               
                if (i == 0)
                {
                    Debug.Log("Comun");
                    Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                }
                else if (i==1)
                {
                    Debug.Log("Poco Comun");
                    Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                }
                else if (i == 2)
                {
                    Debug.Log("Rara");
                    Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                }
                else if (i == 3)
                {
                    Debug.Log("EPICA DORADA");
                    Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                }
                else if (i == 4)
                {
                    Debug.Log("WOOOOOOW LEGENDARIAAAAAAAAAAAA");
                    Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                }

                break;
            }

        }

    }

}
