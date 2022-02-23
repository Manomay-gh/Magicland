using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    GameObject camParent;
    private float Angle;
    // Start is called before the first frame update
    void Start()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 2)
        { Angle = Input.gyro.rotationRateUnbiased.z/2;
           
            camParent.transform.Rotate(0, 0, Angle);
            
        }
    }
}
