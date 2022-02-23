using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraStop : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .CompareTag ("Player"))
        {
            cam.SetActive(false);
        }
    }
}
