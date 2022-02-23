using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class push : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .CompareTag ("Player"))
                {
            animator.SetBool("Push", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Push",false);
        }
    }
}
