using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class OrbButton : MonoBehaviour
{
    public GameObject obj;
   
    public float distance;
    public bool dirxUp;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F) || CrossPlatformInputManager.GetButton("Use"))
            {
                if (dirxUp == true)
                {
                    if (obj.transform.position.y < distance)
                    {
                        obj.transform.Translate(0, 1 * Time.deltaTime, 0);
                    }
                }
                else
                {
                    if (obj.transform.position.y > distance)
                    {
                        obj.transform.Translate(0, -1 * Time.deltaTime, 0);
                    }

                }
                
              
            }
            
        }
    }
}
