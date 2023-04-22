using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charactermovement : MonoBehaviour
{
    public static charactermovement instance { get; set; }
    public float moveSpeed = 5f;
    public float jump_force = 5f;
    Animator anim;
    public float sprintvalue = 1;
    public SpriteRenderer mysprite;
    bool isjump;
    public Rigidbody2D rb;
    int jumps = 0;    
    public int maxJumps = 2;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mysprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isjump = false;

    }
    public void Update()
    {
        jumping();
        moving();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void FixedUpdate()
    {
       
    }

    public void moving()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed * sprintvalue , rb.velocity.y);


        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            mysprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            mysprite.flipX = false;
        };

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            sprintvalue = 2;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            sprintvalue = 1;

        }


        if (moveInput != 0)
        {
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed",0);
        }

    }

    void jumping()
    {
        if (Input.GetButtonDown("Jump") && !isjump)
        {
            rb.velocity = new Vector2(0, jump_force);
            isjump = true;
            anim.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Jump") && jumps < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            jumps++;
            anim.SetTrigger("Jump");
        }


        if (rb.velocity.y == 0)
        {
            anim.SetTrigger("Land");
        }


        if (Mathf.Abs(rb.velocity.y) < 0.01)
            isjump = false;
    }
    
    public void knockbackx(float Force)
    {
        transform.position = new Vector3(transform.position.x + (Force * Time.deltaTime), transform.position.y, transform.position.z);
    }

   
    public void knockbacky(float Force)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Force * Time.deltaTime), transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = 0;
        }

    }
}
