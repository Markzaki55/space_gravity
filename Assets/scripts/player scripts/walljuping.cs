using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class walljuping : MonoBehaviour
{
    public float jumpForce ;
    public float wallJumpTime = 0.2f;
    private bool isWallJumping = false;

    public charactermovement MainCharClass { get; private set; }

    private Rigidbody2D rb;
    

    void Start()
    {
        MainCharClass = GetComponent<charactermovement>();
        jumpForce = MainCharClass.jump_force;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        walljumpin();
    }

    public void walljumpin()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isWallJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(WallJumpCoroutine());
        }
    }
    IEnumerator WallJumpCoroutine()
    {
        float time = 0;
        while (time < wallJumpTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        isWallJumping = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isWallJumping = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isWallJumping = false;
        }
    }
}