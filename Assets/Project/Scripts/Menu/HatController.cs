using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{

    public void DogHatSelected(int hat)
    {
        StaticClass.dogHat = hat;
    }

    public void CatHatSelected(int hat)
    {
        StaticClass.catHat = hat;
    }
}
