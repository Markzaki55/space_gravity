using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randenemyscript : MonoBehaviour
{
    Player_health playerhealth;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveDirection = new Vector2(1f, 0.25f);
    [SerializeField] GameObject rightCheck, roofCheck, groundCheck;
    [SerializeField] Vector2 rightCheckSize, roofCheckSize, groundCheckSize;
    [SerializeField] LayerMask groundLayer, platform;
    [SerializeField] bool goingUp = true;

    private bool touchedGround, touchedRoof, touchedRight;
    private Rigidbody2D EnemyRB;


    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HitLogic();
    }

    void FixedUpdate()
    {
        EnemyRB.velocity = moveDirection * moveSpeed;
    }

    void HitLogic()
    {
        touchedRight = HitDetector(rightCheck, rightCheckSize, (groundLayer | platform));
        touchedRoof = HitDetector(roofCheck, roofCheckSize, (groundLayer | platform));
        touchedGround = HitDetector(groundCheck, groundCheckSize, (groundLayer | platform));

        if (touchedRight)
        {
            Flip();
        }
        if (touchedRoof && goingUp)
        {
            ChangeYDirection();
        }
        if (touchedGround && !goingUp)
        {
            ChangeYDirection();
        }
    }

    bool HitDetector(GameObject gameObject, Vector2 size, LayerMask layer)
    {
        return Physics2D.OverlapBox(gameObject.transform.position, size, 0f, layer);
    }

    void ChangeYDirection()
    {
        moveDirection.y = -moveDirection.y;
        goingUp = !goingUp;
    }

    void Flip()
    {
        transform.Rotate(new Vector2(0, 180));
        moveDirection.x = -moveDirection.x;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheck.transform.position, groundCheckSize);
        Gizmos.DrawWireCube(roofCheck.transform.position, roofCheckSize);
        Gizmos.DrawWireCube(rightCheck.transform.position, rightCheckSize);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerhealth.Damage(1);


            if (transform.position.x < charactermovement.instance.transform.position.x)
            {

                charactermovement.instance.knockbackx(15f);
            }
            else
            {

                charactermovement.instance.knockbackx(-15f);
            }


            if (transform.position.y < charactermovement.instance.transform.position.y)
            {

                charactermovement.instance.knockbacky(5f);
            }
            else if (transform.position.y > charactermovement.instance.transform.position.y)
            {

                charactermovement.instance.knockbacky(-5f);
            }






        }
    }
}
