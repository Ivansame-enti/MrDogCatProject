using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static System.TimeZoneInfo;
using UnityEditor.SearchService;

public class Level1Final : MonoBehaviour
{
    public GameObject flag;
    private TextMeshProUGUI coinTextDog;
    private TextMeshProUGUI coinTextCat;

    [SerializeField]
    private Material transitionMaterial;

    [SerializeField]
    private float transitionTime = 3f;

    [SerializeField]
    private string propertyName = "_Progress";

    // Start is called before the first frame update
    void Start()
    {
        coinTextDog = GameObject.FindGameObjectWithTag("DogCoinText").GetComponent<TextMeshProUGUI>();
        coinTextCat = GameObject.FindGameObjectWithTag("CatCoinText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag.transform.position.y >= 10)
        {
            StartCoroutine(FinishTranition());
        }
    }

    private IEnumerator FinishTranition()
    {
        float currentTime = transitionTime;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            transitionMaterial.SetFloat(propertyName, Mathf.Clamp01(currentTime / transitionTime));
            yield return null;
        }
        StaticClass.CoinsCat = int.Parse(coinTextCat.text);
        StaticClass.CoinsDog = int.Parse(coinTextDog.text);
        SceneManager.LoadScene("Win");
    }
}
