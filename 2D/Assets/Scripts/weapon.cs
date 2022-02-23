using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class weapon : MonoBehaviour
{
    public Text text;
    public Transform firePoint;
    public GameObject BulletPrefab;
    public GameObject HealPrefab;
    public int ammo = 0;
    public int maxammo=3;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (ammo > 0)
        {
            if (Input.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Shoot"))
            {
                animator.SetBool("shoot", true);
                shoot();
            }
                 else
                {
                    animator.SetBool("shoot", false);
                }
        }

        else
        {
            animator.SetBool("shoot", false);
        }
        text.text = ammo.ToString();
    }

    void shoot()
    {
        ammo -= 1;
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {if(collision .gameObject .CompareTag ("Lake"))
        {
            HealPrefab.SetActive(true);
        }
        if (ammo < maxammo)
        {
            if (collision.gameObject.CompareTag("Ammo"))
            {
                ammo += 1;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lake"))
        {
            HealPrefab.SetActive(false);
        }
    }


}
