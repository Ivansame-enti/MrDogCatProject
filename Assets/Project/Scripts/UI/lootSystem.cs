using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class ItemToSpawn
{
    public GameObject[] item;
    public float spawRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}

public class lootSystem : MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;
    public GameObject comunParticles, LittlecomunParticles, RareParticles, EpicParticles, LegendaryParticles;
    GameObject hat;
    public TextMeshProUGUI CoinText;
    public GameObject Explosion;
    public GameObject ExplisionParticles;
    public GameObject panelBlanco;
    private bool AnimacionFinalizada = false;
    private bool unico = true;
    float timer = 0;
    float timer2 = 2;
    private bool unicoPanel = true;
    
    void Start()
    {
        panelBlanco.SetActive(false);
        StaticClass.CoinsDog = 20;
        CoinText.text = StaticClass.CoinsDog.ToString("000");

        for (int i = 0; i < itemToSpawn.Length; i++)
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

        if (StaticClass.CoinsDog >= 10 && AnimacionFinalizada == true)
        {
            ExplisionParticles.SetActive(false);
            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
            Spawner();
        }

    }
    public void Reroll()
    {
        if (StaticClass.CoinsDog >= 10 && AnimacionFinalizada == true)
        {
            ExplisionParticles.SetActive(false);
            panelBlanco.SetActive(false);
            comunParticles.SetActive(false);
            LittlecomunParticles.SetActive(false);
            EpicParticles.SetActive(false);
            RareParticles.SetActive(false);
            LegendaryParticles.SetActive(false);

            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
        }

        ExplisionParticles.SetActive(true);
        unicoPanel = true;
        unico = true;
    }

    void Update()
    {

        if (Explosion.transform.position.z > 500)
        {
            Explosion.SetActive(false);
            AnimacionFinalizada = true;

        }

        if (AnimacionFinalizada)
        {
            if (unicoPanel == true)
            {
                ExplisionParticles.SetActive(false);
                panelBlanco.SetActive(true);
                unicoPanel = false;
            }


            if (timer >= 2) //Un segundo donde el panel se queda full visible
            {
                //panelBlanco.GetComponent<Image>().color = new Color(panelBlanco.GetComponent<Image>().color.r, panelBlanco.GetComponent<Image>().color.g, panelBlanco.GetComponent<Image>().color.b, 0);

                if (unico == true)
                {
                    ExplisionParticles.SetActive(false);
                    // StaticClass.CoinsDog -= 10;
                    Spawner();
                    unico = false;
                    AnimacionFinalizada = true;
                }

                if (timer2 <= 0)
                {
                    //timer = 0f;
                    //timer2 = 0f;
                }
                else
                {
                    Debug.Log(map(timer2, 0, 1, 0, 255));
                    panelBlanco.GetComponent<Image>().color = new Color(panelBlanco.GetComponent<Image>().color.r, panelBlanco.GetComponent<Image>().color.g, panelBlanco.GetComponent<Image>().color.b, map(timer2, 0, 2, 0, 1));
                    timer2 -= Time.deltaTime;
                }
                //panelBlanco.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
            }

        }



    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }


    void Spawner()
    {
        if (hat != null)
        {
            Destroy(hat);
        }

        float randomNum = Random.Range(0, 100);
        int randomNum2 = 0;
        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (randomNum >= itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
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
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                }
                else if (i == 1)
                {
                    Debug.Log("Poco Comun");
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(true);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(false);
                    LegendaryParticles.SetActive(false);
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
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
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
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
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
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
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                }
                break;
            }
        }
    }
}
