using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFloor : MonoBehaviour
{
    private bool returnFloor;
    private float timer;
    public GameObject floor;
    private GameObject clone;
    private LightFloorCollision lightFloorCollision;
    private MeshRenderer rend;
    public float plataformDownTime, respawnTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        rend = GetComponent<MeshRenderer>();

    }
    private void Awake()
    {
        //rend.enabled = false;
        clone = Instantiate(floor, gameObject.transform.position, Quaternion.identity);
        lightFloorCollision = clone.GetComponent<LightFloorCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightFloorCollision.detectPlayer)
        {
            Debug.Log("buenas");
            Destroy(clone, plataformDownTime);
            lightFloorCollision.detectPlayer = false;
            returnFloor = true;
        }
        if(returnFloor)
        {
            Debug.Log("ola");
            timer += Time.deltaTime;
            if(timer >= respawnTime)
            {
                returnFloor = false;
                clone = Instantiate(floor,transform.position,Quaternion.identity);
                lightFloorCollision = clone.GetComponent<LightFloorCollision>();
                timer = 0;
            }
        }

    }
 }
