using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private float timer;

    private void Update()
    {
        //Debug.Log(timer);
        if (timer <= 1f) timer += Time.deltaTime;    
    }

    public void DogHatSelected(int hat)
    {
        if (timer >= 0.5f)
        {
            StaticClass.dogHat = hat;
            this.GetComponent<PlayerSetupMenuController>().ReadyPlayer();
        }
    }

    public void CatHatSelected(int hat)
    {
        if (timer >= 0.5f)
        {
            StaticClass.catHat = hat;
            this.GetComponent<PlayerSetupMenuController>().ReadyPlayer();
        }
    }
}
