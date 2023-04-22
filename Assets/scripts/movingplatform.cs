using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public float speed = 10f;
    public int startingpoint;
    public Transform[] points;
    private int i;

    void Start()
    {
        if (startingpoint >= 0 && startingpoint < points.Length)
        {
            transform.position = points[startingpoint].position;
            i = startingpoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length > 0)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null );
        collision.gameObject.transform.SetParent(GameObject.FindWithTag("Playerparent").transform);
    }



}