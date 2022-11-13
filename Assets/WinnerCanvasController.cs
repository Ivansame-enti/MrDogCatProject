using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerCanvasController : MonoBehaviour
{
    public Slider catSlider, dogSlider;
    private int maxValue;
    private bool catEnded, dogEnded;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        catEnded = false;
        dogEnded = false;
        StaticClass.CoinsCat = 10;
        StaticClass.CoinsDog = 7;
        //Debug.Log(StaticClass.CoinsCat);
        //Debug.Log(StaticClass.CoinsDog);
        
        maxValue = Mathf.Max(StaticClass.CoinsCat, StaticClass.CoinsDog);
        catSlider.maxValue = maxValue;
        dogSlider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CatSliderValueChange(catSlider));
        StartCoroutine(DogSliderValueChange(dogSlider));
        if(catEnded && dogEnded)
        {
            if(StaticClass.CoinsCat > StaticClass.CoinsDog)
            {
                winText.SetActive(true);
                winText.transform.position = new Vector3();
            } else if(StaticClass.CoinsCat < StaticClass.CoinsDog)
            {
                winText.SetActive(true);
                winText.transform.position = new Vector3();
            }
            

        }
    }

    IEnumerator CatSliderValueChange(Slider slider)
    {
        if (slider != null)
        {
            float timeSlice = (slider.value * 0.001f);
            while (slider.value <= StaticClass.CoinsCat)
            {
                slider.value += timeSlice;
                yield return new WaitForSeconds(5f);
                if (slider.value >= StaticClass.CoinsCat)
                    break;
            }
        }
        catEnded = true;
        yield return null;
    }

    IEnumerator DogSliderValueChange(Slider slider)
    {
        if (slider != null)
        {
            float timeSlice = (slider.value * 0.001f);
            while (slider.value <= StaticClass.CoinsDog)
            {
                slider.value += timeSlice;
                yield return new WaitForSeconds(5f);
                if (slider.value >= StaticClass.CoinsDog)
                    break;
            }
        }
        dogEnded = true;
        yield return null;
    }
}
