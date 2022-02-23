using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject controls;
   
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        controls.SetActive(false);

        Invoke("setactive", 10f);
    }

    // Update is called once per frame
   public void setactive()
    {
        gameObject.SetActive(false);
        controls.SetActive(true);
    }

  
}
