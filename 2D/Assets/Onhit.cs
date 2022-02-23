using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onhit : MonoBehaviour
{ public GameObject explosionPrefab;
    public Transform ExplosionOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, ExplosionOffset.position , this.transform.rotation);
            deactivate();
        }
    
    }

  void deactivate()
    {   
        gameObject.SetActive(false);
    }
}
