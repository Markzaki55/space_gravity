using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float starttimeBtwShots;


    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shopt();
            }
            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shopt()
    {
        var newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newBullet.isCharFacingRight = GetComponentInParent<Character>().m_facingRight;
        timeBtwShots = starttimeBtwShots;
    }
}
