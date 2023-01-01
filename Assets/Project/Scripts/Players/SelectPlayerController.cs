using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{
    public GameObject character;
    public GameObject dogPos;
    public ObiParticleAttachment rope;

    public GameObject[] prefabsDog;

    public static Vector3 lastCheckpoint;
    //public static Vector3 dogLastCheckpoint;

    // Start is called before the first frame update
    void Awake()
    {
        SelectCharacter(StaticClass.hatPicked);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Cat" + catLastCheckpoint);
        //Debug.Log("Dog" + dogLastCheckpoint);
    }

    private void SelectCharacter(int num)
    {
        if (lastCheckpoint != Vector3.zero) character.transform.position = lastCheckpoint;

        GameObject dog = Instantiate(prefabsDog[StaticClass.hatPicked], dogPos.transform.position, dogPos.transform.rotation) as GameObject;
        rope.target = dog.transform;
    }
}
