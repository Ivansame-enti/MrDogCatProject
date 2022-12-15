using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{
    public GameObject dogPos;
    public ObiParticleAttachment rope;

    public GameObject[] prefabsDog;

    // Start is called before the first frame update
    void Start()
    {
        switch (StaticClass.hatPicked)
        {
            case 0:
                SelectCharacter(StaticClass.hatPicked);
                break;
            default:
                SelectCharacter(StaticClass.hatPicked);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectCharacter(int num)
    {
        GameObject dog = Instantiate(prefabsDog[StaticClass.hatPicked], dogPos.transform.position, dogPos.transform.rotation) as GameObject;
        rope.target = dog.transform;
    }
}
