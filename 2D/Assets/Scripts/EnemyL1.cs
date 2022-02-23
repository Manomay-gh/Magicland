using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL1 : MonoBehaviour
{
    
    public Rigidbody2D enemyL1;
    public float speed=2f;
    public float stoppingDistance=3f;
    public float minDistance = 10f;

    private Transform target;

    public Animator animate;

    

    public float EnemyHealth=20;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyL1 = GetComponent<Rigidbody2D>(); ;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
                if (Mathf.Abs(transform.position.x - target.position.x) < 1f && Mathf.Abs(transform.position.y - target.position.y) < 1f)
                {
                    animate.SetBool("IsAttacking", true);
                }
                else
                {
                    animate.SetBool("IsAttacking", false);
                    animate.SetBool("IsMoving", true);
                }
                
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            { //move towards player
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (target.position.x > transform.position.x)
            { //face right
                transform.localScale = new Vector3(-0.1349307f, 0.1349307f, 0.1349307f);
            }
            else if (target.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(0.1349307f, 0.1349307f, 0.1349307f);
            }
        }
        else
        {
            animate.SetBool("IsMoving", false);
        }       
    }

    private void Update()
    {
        if(EnemyHealth <=0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .CompareTag ("Bullet"))
        {
            Debug.Log("Trigger");
            EnemyHealth -= 10;


        }
    }





}
