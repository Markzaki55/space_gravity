using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardianboss : MonoBehaviour
{
    //for idel
    [SerializeField] float idelMovementSpeed;
    [SerializeField] Vector2 idelMovementDirection;
    //attack updawn
    [SerializeField] float attackMovementSpeed;
    [SerializeField] Vector2 attackMovementDirection;
    //attack 2
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    //checkpos
    [SerializeField] Transform goundCheckUp;
    [SerializeField] Transform goundCheckDown;
    [SerializeField] Transform goundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool hasPlayerPositon;
    //playerpos
    private Vector2 playerPosition;
    //boss
    private bool facingLeft = true;
    private bool goingUp = true;
    //components
    private Rigidbody2D enemyRB;
    private Animator enemyAnim;
    //lineofsiteforplayer
    public float lineofsite;
    bool hasExecuted = false;


    AudioSource bosscolsound;
     AudioSource bosscharge;


    void Start()
    {
        bosscharge = GameObject.FindGameObjectWithTag("Bosscharce").GetComponent<AudioSource>();
        bosscolsound =  GetComponent<AudioSource>();
        idelMovementDirection.Normalize();
        attackMovementDirection.Normalize();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(goundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(goundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(goundCheckWall.position, groundCheckRadius, groundLayer);
        //to start the boss fight when player gets in his range
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite)
        {
            enemyAnim.SetTrigger("lineofsite");

            if (!hasExecuted)
            {
                bosscharge.Play();
                lineofsite = lineofsite * 2;
                hasExecuted = true;

            }
        }


    }

    // called in an event in the idle animtion to play a random attack
    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            enemyAnim.SetTrigger("AttackUpNDown");
        }
        else if (randomState == 1)
        {
            enemyAnim.SetTrigger("AttackPlayer");
        }
    }

    //called in the state machine
    public void IdelState()
    {
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite)
        {



            if (isTouchingUp && goingUp)
            {
                ChangeDirection();
            }
            else if (isTouchingDown && !goingUp)
            {
                ChangeDirection();
            }

            if (isTouchingWall)
            {
                if (facingLeft)
                {
                    Flip();
                }
                else if (!facingLeft)
                {
                    Flip();
                }
            }

            enemyRB.velocity = idelMovementSpeed * idelMovementDirection;
        }
    }
    //called in the state machine
    public void AttackUpNDownState()
    {
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite)
        {

            if (isTouchingUp && goingUp)
            {
                cinemachineshake.Instance.ShakeCamera(5f, 01f);
                ChangeDirection();
            }
            else if (isTouchingDown && !goingUp)
            {
                cinemachineshake.Instance.ShakeCamera(5f, 01f);
                ChangeDirection();
            }

            if (isTouchingWall)
            {
                cinemachineshake.Instance.ShakeCamera(5f, 0.1f);
                if (facingLeft)
                {
                    Flip();
                }
                else if (!facingLeft)
                {
                    Flip();
                }
            }
            enemyRB.velocity = attackMovementSpeed * attackMovementDirection;
        }
    }

    //called in the state machine
    public void AttackPlayerState()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite)
        {


            if (!hasPlayerPositon)
            {
                FlipTowardsPlayer();
                playerPosition = player.position - transform.position;
                playerPosition.Normalize();
                hasPlayerPositon = true;
            }
            if (hasPlayerPositon )
            {
                enemyRB.velocity = attackPlayerSpeed * playerPosition;

            }


            if (isTouchingWall || isTouchingDown)
            {
                cinemachineshake.Instance.ShakeCamera(5f, 01f);
                enemyAnim.SetTrigger("Slamed");
                enemyRB.velocity = Vector2.zero;
                hasPlayerPositon = false;
            }
        }
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite)
        {

            if (playerDirection > 0 && facingLeft)
            {
                Flip();
            }
            else if (playerDirection < 0 && !facingLeft)
            {
                Flip();
            }
        }
    }

    void ChangeDirection()
    {
        bosscolsound.Play();
        goingUp = !goingUp;
        idelMovementDirection.y *= -1;
        attackMovementDirection.y *= -1;
    }
    
    void Flip()
    {
        facingLeft = !facingLeft;
        idelMovementDirection.x *= -1;
        attackMovementDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(goundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckWall.position, groundCheckRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
    }
}
