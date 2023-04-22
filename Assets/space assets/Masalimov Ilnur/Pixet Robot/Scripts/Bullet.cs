using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;  
    public float lifetime;   
    public float distance;
    public LayerMask whatIsSolid;
    public bool isCharFacingRight = true;
    Rigidbody2D rb;


    void Start()
    {
        Invoke("DestroyBullet", lifetime);
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = isCharFacingRight ? -transform.right : transform.right;
        rb.velocity = direction * speed;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)  
        {
            DestroyBullet();
        }
 
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);  
    }
}
