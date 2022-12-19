using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject comunParticles, LittlecomunParticles, RareParticles, EpicParticles, LegendaryParticles;
    GameObject hat;
    //private float monedas;
    public TextMeshProUGUI CoinText;
    void Start()
    {

        StaticClass.CoinsDog = 100000;
        CoinText.text = StaticClass.CoinsDog.ToString("000");
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

        if( StaticClass.CoinsDog >= 10) {
            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
            Spawner();
        }

    }
    public void Reroll()
    {
        Debug.Log("HELICOPTERO");

        if (StaticClass.CoinsDog >= 10)
        {
            comunParticles.SetActive(false);
            LittlecomunParticles.SetActive(false);
            EpicParticles.SetActive(false);
            RareParticles.SetActive(false);
            LegendaryParticles.SetActive(false);

            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
            Spawner();
        }


    }

    void Update()
    {
      




    }

    void Spawner()
    {

        if (hat!=null){

            Destroy(hat);
        }
     


        float randomNum = Random.Range(0, 100);
        int randomNum2 = 0;
        for (int i=0; i<itemToSpawn.Length; i++)
        {

            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {

               
                if (i == 0)
                {
                    Debug.Log("Comun");
                    comunParticles.SetActive(true);
                    LittlecomunParticles.SetActive(false);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(false);
                    LegendaryParticles.SetActive(false);
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    Debug.Log(randomNum2);
                     hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i==1)
                {
                    Debug.Log("Poco Comun");
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(true);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(false);
                    LegendaryParticles.SetActive(false);
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                     hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 2)
                {
                    Debug.Log("Rara");
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(false);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(true);
                    LegendaryParticles.SetActive(false);
                     hat = Instantiate(itemToSpawn[i].item[0], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 3)
                {
                    Debug.Log("EPICA DORADA");
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(false);
                    EpicParticles.SetActive(true);
                    RareParticles.SetActive(false);
                    LegendaryParticles.SetActive(false);
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                     hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (i == 4)
                {
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(false);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(false);
                    LegendaryParticles.SetActive(true);
                    Debug.Log("WOOOOOOW LEGENDARIAAAAAAAAAAAA");
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                     hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                }

                break;
            }

        }

    }

}
