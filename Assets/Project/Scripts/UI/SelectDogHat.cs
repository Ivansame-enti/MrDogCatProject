using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectDogHat : MonoBehaviour
{

    public GameObject[] prefabsDog;
    private GameObject preView;
    private void Update()
    {
        //if (EventSystem.current.currentSelectedGameObject == this.transform.GetChild(2).gameObject) preView = Instantiate(prefabsDog[0], new Vector3(0,0,0), Quaternion.identity) as GameObject;
    }

    public void SelectHat0()
    {
        StaticClass.hatPicked = 0;
        SceneManager.LoadScene("Tutorial 1");
    }

    public void SelectHat1()
    {
        StaticClass.hatPicked = 1;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectHat2()
    {
        StaticClass.hatPicked = 2;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectHat3()
    {
        StaticClass.hatPicked = 3;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectHat4()
    {
        StaticClass.hatPicked = 4;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectHat5()
    {
        StaticClass.hatPicked = 5;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectHat6()
    {
        StaticClass.hatPicked = 6;
        SceneManager.LoadScene("Tutorial");
    }
}
