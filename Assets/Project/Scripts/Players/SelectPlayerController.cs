using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class SelectPlayerController : MonoBehaviour
{
    public GameObject dogPos;
    public GameObject catPos;
    public ObiParticleAttachment dogRope;
    public ObiParticleAttachment catRope;

    public GameObject[] prefabsDog;
    public GameObject[] prefabsCat;

    // Start is called before the first frame update
    void Awake()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i<playerConfigs.Length; i++)
        {
            if(i == 0)
            {
                GameObject dog = Instantiate(prefabsDog[StaticClass.dogHat], dogPos.transform.position, dogPos.transform.rotation) as GameObject;
                dogRope.target = dog.transform;
                dog.GetComponent<playerInputHandler>().InitializePlayer(playerConfigs[i]);
            }
            if(i == 1)
            {
                GameObject cat = Instantiate(prefabsCat[StaticClass.catHat], catPos.transform.position, catPos.transform.rotation) as GameObject;
                catRope.target = cat.transform;
                cat.GetComponent<playerInputHandler>().InitializePlayer(playerConfigs[i]);
                
            }
        }
        //if(animalPos.tag == "Dog") SelectCharacterDog(StaticClass.dogHat);
        //if(animalPos.tag == "Cat") SelectCharacterCat(StaticClass.catHat);
        Debug.Log(StaticClass.dogHat);
        Debug.Log(StaticClass.catHat);
    }

    /*
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
    */
}
