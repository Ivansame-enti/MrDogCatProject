using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerCanvasController : MonoBehaviour
{
    public Slider catSlider, dogSlider;
    private int maxValue;
    private bool catEnded, dogEnded,winnerSound,winnerMusic;
    public GameObject winTextCat, winTextDog;
    public GameObject button;
    public GameObject coinDog, coinCat;
    private AudioManagerController audioSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        catEnded = false;
        dogEnded = false;
       // StaticClass.CoinsCat = 10;
        //StaticClass.CoinsDog = 7;
       // Debug.Log(StaticClass.CoinsCat);
       // Debug.Log(StaticClass.CoinsDog);
        
        maxValue = Mathf.Max(StaticClass.CoinsCat, StaticClass.CoinsDog);
        catSlider.maxValue = maxValue;
        dogSlider.maxValue = maxValue;
        audioSFX.AudioPlay("WinningBar");
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(CatSliderValueChange(catSlider));
        //StartCoroutine(DogSliderValueChange(dogSlider));

        if (catSlider.value >= StaticClass.CoinsCat) catEnded = true;
        else catSlider.value += Time.deltaTime * 3f;

        if (dogSlider.value >= StaticClass.CoinsDog) dogEnded = true;
        else dogSlider.value += Time.deltaTime * 3f;

        if (catEnded) coinCat.SetActive(false);
        if (dogEnded) coinDog.SetActive(false);

        if (catEnded && dogEnded)
        {
            audioSFX.AudioStop("WinningBar");
            if (!winnerMusic)
                audioSFX.AudioPlay("WinMusic");
            winnerMusic = true;
            if (StaticClass.CoinsCat > StaticClass.CoinsDog)
            {
                winTextCat.SetActive(true);
                if(!winnerSound) audioSFX.AudioPlay("Meow");
                winnerSound = true;

            } else if(StaticClass.CoinsCat < StaticClass.CoinsDog)
            {
                winTextDog.SetActive(true);
                if (!winnerSound) audioSFX.AudioPlay("Bark");
                winnerSound = true; 
            }

            button.SetActive(true);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("LootBox");
    }
}
