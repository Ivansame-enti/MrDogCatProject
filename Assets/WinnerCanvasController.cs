using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerCanvasController : MonoBehaviour
{
    public Slider catSlider, dogSlider;
    private int maxValue;
    private bool catEnded, dogEnded;
    public GameObject winTextCat, winTextDog;
    private float fillQuantity = 0.01f;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        catEnded = false;
        dogEnded = false;
        //StaticClass.CoinsCat = 10;
        //StaticClass.CoinsDog = 7;
        //Debug.Log(StaticClass.CoinsCat);
        //Debug.Log(StaticClass.CoinsDog);
        
        maxValue = Mathf.Max(StaticClass.CoinsCat, StaticClass.CoinsDog);
        catSlider.maxValue = maxValue;
        dogSlider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(CatSliderValueChange(catSlider));
        //StartCoroutine(DogSliderValueChange(dogSlider));

        if (catSlider.value >= StaticClass.CoinsCat) catEnded = true;
        else catSlider.value += Time.deltaTime *2f;

        if (dogSlider.value >= StaticClass.CoinsDog) dogEnded = true;
        else dogSlider.value += Time.deltaTime* 2f;

        if (catEnded && dogEnded)
        {
            if(StaticClass.CoinsCat > StaticClass.CoinsDog)
            {
                winTextCat.SetActive(true);
            } else if(StaticClass.CoinsCat < StaticClass.CoinsDog)
            {
                winTextDog.SetActive(true);
            }

            button.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
