using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{
    public GameObject dogPos;
    public ObiParticleAttachment rope;

    public GameObject[] prefabsDog;

    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Awake()
    {
        SelectCharacter(StaticClass.hatPicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectCharacter(int num)
    {
        GameObject dog = Instantiate(prefabsDog[StaticClass.hatPicked], dogPos.transform.position, dogPos.transform.rotation) as GameObject;
        rope.target = dog.transform;

        if (virtualCamera != null) virtualCamera.Follow = dog.transform;
        if (virtualCamera != null) virtualCamera.LookAt = dog.transform;

    }
}
