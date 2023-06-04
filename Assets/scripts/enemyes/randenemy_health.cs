using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randenemy_health : MonoBehaviour,Idamageable
{
    public GameObject explosion;
    SimpleFlash simpleflash;
    [SerializeField] int Rmaxhealth = 5;
    public int Rcurrethealth;



    void Awake()
    {

    }
    void Start()
    {
        simpleflash = GetComponent<SimpleFlash>();

        Rcurrethealth = Rmaxhealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Takedamage(int amount)
    {
        Rcurrethealth -= amount;
        simpleflash.Flash();

        if (transform.position.x < charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - (GameManger.instance.knockforce * Time.deltaTime), transform.position.y + (GameManger.instance.knockforce * Time.deltaTime), transform.position.z);
        }
        else if (transform.position.x > charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + (GameManger.instance.knockforce * Time.deltaTime), transform.position.y + (GameManger.instance.knockforce * Time.deltaTime), transform.position.z);
        }


        Debug.Log($"Renemy health : {Rcurrethealth}");
        if (Rcurrethealth <= 0)
        {
            Rcurrethealth = 0;
            GameObject explosion1 = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosion1, 2);
            Debug.Log("the jRenemy is dead");
            Destroy(gameObject);

        }
    }
}
