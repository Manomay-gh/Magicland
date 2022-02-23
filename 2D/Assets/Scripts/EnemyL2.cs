using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL2 : MonoBehaviour
{

    public Rigidbody2D enemy;
    public float speed = 2f;
    public float stoppingDistance = 3f;
    public float minDistance = 10f;

    private Transform target;

    public Animator animate;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); ;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {

            animate.SetBool("L2IsMoving", true);

            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (target.position.x > transform.position.x)
            { //face right
                transform.localScale = new Vector3(-0.1038427f, 0.1038427f, 0.1038427f);
            }
            else if (target.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(0.1038427f, 0.1038427f, 0.1038427f);
            }


        }
        else
        {
            animate.SetBool("L2IsMoving", false);
        }


    }



}
