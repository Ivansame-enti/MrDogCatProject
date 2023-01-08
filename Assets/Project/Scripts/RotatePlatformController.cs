using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformController : MonoBehaviour
{
    public bool hasToMove;
    int vueltas = 0;
    bool flagVueltas = false;
    public GameObject platform;
    private float valueMapped;
    private float lastRotationValue;
    private float platformOriginalY, originalY;
    bool goodDirection=true;
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        originalY = this.transform.position.y;
        platformOriginalY = platform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentRotation = transform.rotation.eulerAngles;
        /*if (currentRotation.y < 0) { currentRotation.y += 360; }
        if (currentRotation.y > 180) { currentRotation.y -= 360;  }
        //currentRotation.y = (currentRotation.y > 360) ? currentRotation.y - 360 : currentRotation.y;
        if (currentRotation.y > 180) { currentRotation.y = 180; }
        if (currentRotation.y < -180) { currentRotation.y = -180;  }
        //currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);*/

        /*float rotateAngle = this.transform.localEulerAngles.y;
        // Convert negative angle to positive angle
        rotateAngle = (rotateAngle > 180) ? rotateAngle - 360 : rotateAngle;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, rotateAngle, this.transform.localEulerAngles.z);*/

        //Debug.Log(this.transform.localEulerAngles.y);
        if (lastRotationValue >= 0 && this.transform.localEulerAngles.y <= 5) goodDirection = true;
        if(lastRotationValue <= 5 && this.transform.localEulerAngles.y >= 300) goodDirection = false;

        if (goodDirection)
        {
            if (this.transform.localEulerAngles.y >= 320f && !flagVueltas)
            {
                flagVueltas = true;
                //middlePoint = false;
            }

            if (this.transform.localEulerAngles.y <= 5f && flagVueltas)
            {
                vueltas++;
                flagVueltas = false;
            }

            valueMapped = Map(this.transform.localEulerAngles.y + (320f * vueltas), 0, 600, 0, 1);
            platform.transform.position = new Vector3(platform.transform.position.x, platformOriginalY + Mathf.Lerp(0, maxHeight, valueMapped), platform.transform.position.z);
            if(hasToMove) this.transform.position = new Vector3(this.transform.position.x, originalY + Mathf.Lerp(0, maxHeight, valueMapped), this.transform.position.z);
        }
        lastRotationValue = this.transform.localEulerAngles.y;
    }
    
    float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}
