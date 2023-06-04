using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normaspikes : MonoBehaviour
{
    public Player_health playerHealth;
    Rigidbody2D rb;
    public float knockback = 10f;
    private float damageTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && damageTimer <= 0)
        {
          Idamageable idamage = collision.GetComponent<Idamageable>();
        if(idamage != null&& damageTimer <= 0){
           // Destroy(gameObject);
            idamage.Takedamage(1);
            
        }
            damageTimer = 0.5f;
            rb.velocity = new Vector2(-knockback, knockback); 
        }
    }
}