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
        if(animalPos.tag == "Dog") SelectCharacter(StaticClass.dogHat);
        if(animalPos.tag == "Cat") SelectCharacter(StaticClass.catHat);
    }


    private void SelectCharacter(int num)
    {
        GameObject dog = Instantiate(prefabsDog[StaticClass.dogHat], animalPos.transform.position, animalPos.transform.rotation) as GameObject;
        rope.target = dog.transform;
    }
}
