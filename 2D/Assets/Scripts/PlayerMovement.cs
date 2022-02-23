using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed,gyroSpeed;
    float dirx;
    public float jumpforce;
    private float moveInput,moveGyro;

    private Rigidbody2D rb;

   public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

   private int extraJumps;

    public int extraJumpValue=2;

    public Animator animator;

    bool jumpBool=false;

    public Joystick joystick;

    public bool isAndroid=false;

    bool isCollidingEnemy=false;

    public Image image;
    bool Onplatform = false;

    public float maxHealth = 30;
    public float PlayerHealth = 15;

    public HealthBar healthbar;

    private void Start()
    {
        extraJumps = extraJumpValue;  //set max no. jump values
        rb = GetComponent<Rigidbody2D>(); 
        image.enabled = false;  //Blood Canvas is switched off
        
        healthbar.SetMaxHealth(maxHealth); //healthbar range

        healthbar.SetHealth(PlayerHealth); //health at start
        
    }

    private void FixedUpdate()
    { if (!isCollidingEnemy)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //check ground for jump
            if (isAndroid == true)
            { 
                // Joystick Movement

                if (joystick.Horizontal >= .2f)
                {
                    moveInput = +1;
                }
                else if (joystick.Horizontal <= -0.2f)
                {
                    moveInput = -1;
                }
                else
                {
                    moveInput = 0f;
                }
            }
            else
            {
                //KeyBoard Movement

                moveInput = Input.GetAxis("Horizontal");

            }

            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //sets Running animation

            //Flip character
            if (facingRight == false && (moveInput > 0))
            {
                flip();
            }
            else if (facingRight == true && (moveInput < 0))
            {
                flip();
            }

        }
        
        
    }
    private void Update()
    {
        healthbar.SetHealth(PlayerHealth);
        if (PlayerHealth <=0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //change to next scene

        }
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
            if ((Input.GetKeyDown(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump")) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                extraJumps--;
              
            }
            else if ((Input.GetKeyDown(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump")) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpforce;
               
            }
        
         
            if (rb.velocity.y != 0 && Onplatform == false && isGrounded == false)
            {
                animator.SetBool("IsJumping", true);
            }
           else if(rb.velocity.y==0 || Onplatform == true )
            {
                animator.SetBool("IsJumping", false);
            }
    }

    //Flip character FUNCTION
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
   
        void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision .gameObject.CompareTag("Platform")) //For Platform Parent
        {
            Onplatform = true;
            this.transform.parent = collision.transform;
        }
        if(collision .gameObject .CompareTag ("Lava")) //Lava Death
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("Enemy")) // Enemy Damage
        {
            PlayerHealth -= 5;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //Bounce Away from Enemy On hit
        {
            isCollidingEnemy = true;
            float bounce = 70f; //amount of force to apply
            rb.AddForce(collision.contacts[0].normal * bounce);
            image.enabled = true;
            Invoke("StopBounce", 0.2f);
            Invoke("changecolorred", 0.2f);
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) //Platform Set Parent - Null
        {
            Onplatform = false;
            this.transform.parent = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lake")) //Heal On Lake
        {
            Invoke("IncreaseHealth", 0.5f);
        }

       
    }

    //Enemy Bounce Stopping Function
    void StopBounce()
    {
        isCollidingEnemy = false;
    }

    //Change Color Of Damage Screen On hit Enemy
    void changecolorred()
    {
        image.enabled = false;
    }

    void IncreaseHealth()
    {  if (PlayerHealth < maxHealth)
        {
            PlayerHealth += 5;


                }
    }
}
