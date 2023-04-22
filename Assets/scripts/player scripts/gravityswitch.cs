using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class gravityswitch : MonoBehaviour
{
    AudioSource gravitysound;
    Shooting shootscript;

    Rigidbody2D rb;
    private bool top = false;
     SpriteRenderer mysprite;

    void Start()
    {
        gravitysound = GetComponent<AudioSource>();
        shootscript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Shooting>();
        mysprite = GetComponent<charactermovement>().mysprite;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Gravitywitcher();
    }

    public void FixedUpdate()
    {
        Rotation();
       
    }

    public void Gravitywitcher()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gravitysound.Play();
            rb.gravityScale *= -1;
            top = !top;

           // shootscript.enabled = !shootscript.enabled;

        }
    }


    public void Rotation()
    {



        if (top != false)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            transform.eulerAngles = new Vector3(0, 0, 180);
            
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            transform.eulerAngles = Vector3.zero;
        }
    }




    






}
