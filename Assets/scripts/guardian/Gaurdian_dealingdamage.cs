using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaurdian_dealingdamage : MonoBehaviour
{
    Player_health playerhealth1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerhealth1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void OnCollisionEnter2D(Collision2D collision)
    {

          if (collision.gameObject.CompareTag("Player"))
        {
            Idamageable idamage = collision.gameObject.GetComponent<Idamageable>();
            if (idamage != null)
            {
                idamage.Takedamage(1);
            }
        }
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


