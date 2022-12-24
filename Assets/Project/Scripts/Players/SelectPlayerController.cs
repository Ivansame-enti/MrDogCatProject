using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{
    public GameObject animalPos;
    public ObiParticleAttachment rope;

    public GameObject[] prefabsDog;

    // Start is called before the first frame update
    void Awake()
    {
        if(animalPos.tag == "Dog") SelectCharacterDog(StaticClass.dogHat);
        if(animalPos.tag == "Cat") SelectCharacterCat(StaticClass.catHat);
        Debug.Log(StaticClass.dogHat);
        Debug.Log(StaticClass.catHat);
    }


    private void SelectCharacterDog(int num)
    {
        GameObject dog = Instantiate(prefabsDog[StaticClass.dogHat], animalPos.transform.position, animalPos.transform.rotation) as GameObject;
        rope.target = dog.transform;
    }
    private void SelectCharacterCat(int num)
    {
        GameObject cat = Instantiate(prefabsDog[StaticClass.catHat], animalPos.transform.position, animalPos.transform.rotation) as GameObject;
        rope.target = cat.transform;
    }
}
