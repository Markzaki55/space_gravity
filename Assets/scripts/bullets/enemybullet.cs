using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class enemybullet : MonoBehaviour

{
    public static enemybullet instance { get; set; }

    public Player_health playerHealth;
    GameObject player;
    public float speed = 9;
    Rigidbody2D rb;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        bulletE();
        Destroy(gameObject, 2);


    }

    // Update is called once per frame
    void Update()
    {

    }


    void bulletE()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Player_health>();
        Vector2 movdir = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(movdir.x, movdir.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Idamageable idamage = collision.GetComponent<Idamageable>();
        if(idamage != null){
            Destroy(gameObject);
            idamage.Takedamage(1);
            
            
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
                
                charactermovement.instance.knockbacky(10f);
            }
            else if (transform.position.y > charactermovement.instance.transform.position.y)
            {
                
                charactermovement.instance.knockbacky(-10f);
            }




        }
        if (collision.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}}