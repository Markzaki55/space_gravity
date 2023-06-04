using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_BehaviourScript : MonoBehaviour
{
    public ParticleSystem explosion;

    Vector3 mousepos;
    Camera thecam;
    Rigidbody2D rb;
    public float force = 0.3f;

    void Start()
    {
        Destroy(gameObject, 2);
        bulletbeh();
    }

    void bulletbeh()
    {
        // Find the main camera and get the mouse position in world space
        thecam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousepos = thecam.ScreenToWorldPoint(Input.mousePosition);

        // Set the bullet's velocity towards the mouse position
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = mousepos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy(gameObject);
if(!collision.gameObject.CompareTag("Player")){
        Idamageable idamage = collision.GetComponent<Idamageable>();
        if(idamage != null){
           // Destroy(gameObject);
            idamage.Takedamage(1);
            
        }
}
    
        // Check if the bullet collided with the ground
        if (collision.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}