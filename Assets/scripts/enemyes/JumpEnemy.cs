using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpEnemy : MonoBehaviour
{

    Player_health playerhealth;

    public float movespeed = 10f;
    float movedirectin = 1;
    bool facingright = true;
    public Transform wallcheckPoint;
    public Transform groundcheckPoint;
    public float circleRadius;
    public LayerMask groundclayer;
    bool wallcheck;
    bool groundcheck;


    public float JumpHight;
    public Transform player;
    public Transform isground;
    public Vector2 boxsize;
    public bool isGrounded;


    public Vector2 lineofsite;
    public LayerMask playerlayer;
    bool canseeplayer;



    Animator enemyanim;
    Rigidbody2D enemRB;


    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        enemRB = GetComponent<Rigidbody2D>();
        enemyanim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        wallcheck = Physics2D.OverlapCircle(wallcheckPoint.position, circleRadius, groundclayer);
        isGrounded = Physics2D.OverlapCircle(groundcheckPoint.position, circleRadius, groundclayer);
        canseeplayer = Physics2D.OverlapBox(transform.position, lineofsite, 0, playerlayer);

        if (!canseeplayer && isGrounded)
        {
            patroling();
        }
        else if (canseeplayer)
        {
            JumpAttack();
            fliptoplayer();
        }

        animatorcontrol();
    }

    void animatorcontrol()
    {
        enemyanim.SetBool("canseeplayer", canseeplayer);
        enemyanim.SetBool("isGrounded", isGrounded);
    }

    void JumpAttack()
    {
        float Playerposition = player.position.x - transform.position.x;
        if (isGrounded)
        {
            enemRB.velocity = new Vector2(Playerposition, JumpHight) ;
        }
    }

    void fliptoplayer()
    {
        float Playerposition = player.position.x - transform.position.x;
        if (Playerposition < 0 && facingright)
        {
            Flip();
        }
        else if (Playerposition > 0 && !facingright)
        {
            Flip();
        }
    }

    void patroling()
    {
        if (!isGrounded || wallcheck)
        {
            Flip();
        }

        enemRB.velocity = new Vector2(movespeed * movedirectin, enemRB.velocity.y);
    }

    void Flip()
    {
        movedirectin *= -1;
        facingright = !facingright;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundcheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallcheckPoint.position, circleRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(isground.position, boxsize);
        Gizmos.DrawWireCube(transform.position, lineofsite);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            playerhealth.Damage(1);
            if (transform.position.x < charactermovement.instance.transform.position.x)
            {

                charactermovement.instance.knockbackx(10f);
            }
            else
            {

                charactermovement.instance.knockbackx(-10f);
            }


            if (transform.position.y < charactermovement.instance.transform.position.y)
            {

                charactermovement.instance.knockbacky(2.5f);
            }
            else if (transform.position.y > charactermovement.instance.transform.position.y)
            {

                charactermovement.instance.knockbacky(-2.5f);
            }
        }
    }
}
