using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level1Controller : MonoBehaviour
{
    public GameObject objective1;
    public GameObject objective2;
    public PickUpController pickUpDog, pickUpCat;
    // Start is called before the first frame update
    void Start()
    {
        //StaticClass.CrossSceneInformation = "Hello Scene2!";
        //SceneManager.LoadScene("Test2");
    }

    // Update is called once per frame
    void Update()
    {
        if (objective1 == null && objective2 == null)
        {
            StaticClass.CoinsCat = pickUpCat.coinNumber;
            StaticClass.CoinsDog = pickUpDog.coinNumber;
            SceneManager.LoadScene("Win");

        }
    }
}
