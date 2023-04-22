using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Enemyfolowwithshooting : MonoBehaviour
{
    public float speed = 5f;
    public float lineofsite;
    public float shootingarng;
    public GameObject bullet;
    public GameObject bulletparent;
    public float firerate = 1f;
    float nextfiretime;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    // Update is called once per frame
    void Update()
    {


        moveshoot();


    }

     void moveshoot()
    {
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineofsite && distancefromplayer > shootingarng)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distancefromplayer <= shootingarng && nextfiretime < Time.time)
        {
            Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
            nextfiretime = firerate + Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, shootingarng);
    }
}
