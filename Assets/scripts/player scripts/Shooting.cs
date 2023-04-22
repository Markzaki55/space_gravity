using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
     AudioSource gunsound;
    private Camera thecam;
    private Vector3 mousepos;
    public GameObject bullet;
    public Transform bullettTras;
    public bool canfire = true;
    float timer;
    private bool useAltDirection = false;
    public float timebetween;
    void Start()
    {
        gunsound = GetComponent<AudioSource>();
        thecam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }


    void Update()
    {
        shoot();
    }


    //public void shoot()
    //{
    //    mousepos = thecam.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 rotation = mousepos - transform.position;
    //    float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rotZ);

    //    if (!canfire)
    //    {
    //        timer += Time.deltaTime;
    //        if (timer > timebetween)
    //        {
    //            canfire = true;
    //            timer = 0;
    //        }
    //    }

    //    if (Input.GetMouseButton(0) && canfire)
    //    {
    //        canfire = false;
    //      gunsound.Play();
    //        Instantiate(bullet, bullettTras.position, Quaternion.identity);
    //    }
    //}



    public void shoot()
    {
        mousepos = thecam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousepos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float altAngle = angle + 180f;
        Vector3 altDirection = Quaternion.Euler(0f, 0f, altAngle) * Vector3.right;

        if (Input.GetKeyDown(KeyCode.E))
        {
            useAltDirection = !useAltDirection;
        }

        if (useAltDirection)
        {
            transform.rotation = Quaternion.Euler(0, 0, altAngle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (!canfire)
        {
            timer += Time.deltaTime;
            if (timer > timebetween)
            {
                canfire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canfire)
        {
            canfire = false;
            gunsound.Play();

            if (useAltDirection)
            {
                Instantiate(bullet, bullettTras.position, Quaternion.LookRotation(Vector3.forward, altDirection));
            }
            else
            {
                Instantiate(bullet, bullettTras.position, Quaternion.LookRotation(Vector3.forward, direction));
            }
        }
    }


}

