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
        StaticClass.hat1Picked = true;
        SceneManager.LoadScene("MapaMergePablo");
    }

    public void SelectHat2()
    {
        StaticClass.hat2Picked = true;
        SceneManager.LoadScene("MapaMergePablo");
    }

    public void SelectHat3()
    {
        StaticClass.hat3Picked = true;
        SceneManager.LoadScene("MapaMergePablo");
    }
}
