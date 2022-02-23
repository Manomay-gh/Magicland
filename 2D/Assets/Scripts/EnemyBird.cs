using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    public float speed = 1f;

    public bool MoveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-0.1147f, 0.1147f, 0.1147f);
        }
    else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(+0.1147f, 0.1147f, 0.1147f);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag ("Collider"))
        {
            if(MoveRight)
            { MoveRight = false;
            }
            else
            { MoveRight = true;
            }
        }
    }
}
