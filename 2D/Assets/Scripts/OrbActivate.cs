using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbActivate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject orb;
    public GameObject  button;
    private void Start()
    {
        orb.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orb.SetActive(true);
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            orb.SetActive(false);
            button.SetActive(false);
        }
    }
}
