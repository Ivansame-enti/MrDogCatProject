using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDogHat : MonoBehaviour
{
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

    public void SelectHat4()
    {
        StaticClass.hatPicked = 4;
        SceneManager.LoadScene("MapaMergePablo");
    }

    public void SelectHat5()
    {
        StaticClass.hatPicked = 5;
        SceneManager.LoadScene("MapaMergePablo");
    }
}
