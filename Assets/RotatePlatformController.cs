using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformController : MonoBehaviour
{

    float minRotation = 0;
    float maxRotation = 180;
    int vueltas = 0;
    bool flagVueltas = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(this.transform.localEulerAngles.y >= 350f && !flagVueltas)
        {
            vueltas++;
            flagVueltas = true;
        }

        if (this.transform.localEulerAngles.y <= 100f) flagVueltas = false;

        //Debug.Log(vueltas);
        Debug.Log(this.transform.localEulerAngles.y + (360f * vueltas));
        //if (this.transform.rotation.y < 0f) transform.Rotate(0, 0, 0);
        //if (this.transform.rotation.y > 360f) transform.Rotate(0, 360, 0);
    }
}
