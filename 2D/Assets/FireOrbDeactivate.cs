using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrbDeactivate : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .CompareTag ("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
