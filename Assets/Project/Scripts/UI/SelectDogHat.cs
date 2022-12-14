using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDogHat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHat1()
    {
        StaticClass.hatPicked = 1;
        SceneManager.LoadScene("MapaMergePablo");
    }

    public void SelectHat2()
    {
        StaticClass.hatPicked = 2;
        SceneManager.LoadScene("MapaMergePablo");
    }

    public void SelectHat3()
    {
        StaticClass.hatPicked = 3;
        SceneManager.LoadScene("MapaMergePablo");
    }
}
