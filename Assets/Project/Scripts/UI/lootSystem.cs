using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    private bool AnimacionFinalizada = true;
    private bool unico = true;
    float timer = 0;
    float timer2 = 2;
    private bool unicoPanel = true;
    Animator anim;
    public GameObject rollButton;
    public GameObject returnButton;
    public EventSystem eventSystem;


    void Start()
    {
        anim = Explosion.GetComponent<Animator>();
        panelBlanco.SetActive(false);
        StaticClass.CoinsDog = 100;
        CoinText.text = StaticClass.CoinsDog.ToString("000");
        ExplisionParticles.SetActive(false);

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
            AnimacionFinalizada = false;
            anim.SetBool("Anim", true);
            ExplisionParticles.SetActive(true);
            panelBlanco.SetActive(false);
            comunParticles.SetActive(false);
            LittlecomunParticles.SetActive(false);
            EpicParticles.SetActive(false);
            RareParticles.SetActive(false);
            LegendaryParticles.SetActive(false);
            rollButton.SetActive(false);
            returnButton.SetActive(false);
            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
        }

        unicoPanel = true;
        unico = true;

    }
    public void Reroll()
    {
        if (StaticClass.CoinsDog >= 10 && AnimacionFinalizada == true)
        {
            AnimacionFinalizada = false;
            anim.SetBool("Anim", true);
            ExplisionParticles.SetActive(true);
            panelBlanco.SetActive(false);
            comunParticles.SetActive(false);
            LittlecomunParticles.SetActive(false);
            EpicParticles.SetActive(false);
            RareParticles.SetActive(false);
            LegendaryParticles.SetActive(false);

            StaticClass.CoinsDog -= 10;
            CoinText.text = StaticClass.CoinsDog.ToString("000");
        }
    
        unicoPanel = true;
        unico = true;
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {

        //Cuanndo termina la animacion de la pelota
        if (Explosion.transform.position.z > 500 && !AnimacionFinalizada)
        {
            Explosion.SetActive(false);
            anim.SetBool("Anim", false);

            if (unicoPanel == true)
            {
                ExplisionParticles.SetActive(false);
                panelBlanco.SetActive(true);
                unicoPanel = false;
            }

            if (timer >= 2) //Un segundo donde el panel se queda full visible
            {
                if (unico == true)
                {
                    ExplisionParticles.SetActive(false);
                    // StaticClass.CoinsDog -= 10;
                    Spawner();
                    unico = false;
                }

                if (timer2 <= 0)
                {
                    AnimacionFinalizada = true;
                    rollButton.SetActive(true);
                    //eventSystem.SetSelectedGameObject(rollButton, null);
                    returnButton.SetActive(true);
                }
                else
                {
                    panelBlanco.GetComponent<Image>().color = new Color(panelBlanco.GetComponent<Image>().color.r, panelBlanco.GetComponent<Image>().color.g, panelBlanco.GetComponent<Image>().color.b, map(timer2, 0, 2, 0, 1));
                    timer2 -= Time.deltaTime;
                }
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
                    hat.AddComponent<Rotate>();
                    hat.GetComponent<Rotate>().speed=50;
                    hat.GetComponent<Rotate>().ForwardY=true;
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
                    hat.AddComponent<Rotate>();
                    hat.GetComponent<Rotate>().speed = 50;
                    hat.GetComponent<Rotate>().ForwardY = true;
                }
                else if (i == 2)
                {
                    Debug.Log("Rara");
                    comunParticles.SetActive(false);
                    LittlecomunParticles.SetActive(false);
                    EpicParticles.SetActive(false);
                    RareParticles.SetActive(true);
                    LegendaryParticles.SetActive(false);
                    randomNum2 = Random.Range(0, itemToSpawn[i].item.Length);
                    hat = Instantiate(itemToSpawn[i].item[randomNum2], transform.position, itemToSpawn[i].item[randomNum2].transform.rotation);
                    hat.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    hat.AddComponent<Rotate>();
                    hat.GetComponent<Rotate>().speed = 50;
                    hat.GetComponent<Rotate>().ForwardY=true;
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
                    hat.AddComponent<Rotate>();
                    hat.GetComponent<Rotate>().speed = 50;
                    hat.GetComponent<Rotate>().ForwardY=true;
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
                    hat.AddComponent<Rotate>();
                    hat.GetComponent<Rotate>().speed = 50;
                    hat.GetComponent<Rotate>().ForwardY=true;
                }
                break;
            }
        }
    }
}
