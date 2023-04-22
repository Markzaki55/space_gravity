using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public GameObject explosion;
    SimpleFlash simpleflash;
    [SerializeField] int Emaxhealth = 3;
    public int Ecurrethealth;

    void Start()
    {
        simpleflash = GetComponent<SimpleFlash>();
        Ecurrethealth = Emaxhealth;
    }

    public void enemytakindamage(int amount)
    {
        Ecurrethealth -= amount;
        simpleflash.Flash();

        if (transform.position.x < charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - (GameManger.instance.knockforce * Time.deltaTime), transform.position.y + (GameManger.instance.knockforce * Time.deltaTime), transform.position.z);
        }
        else if (transform.position.x > charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + (GameManger.instance.knockforce * Time.deltaTime), transform.position.y + (GameManger.instance.knockforce * Time.deltaTime), transform.position.z);
        }
        Debug.Log($"enemy health : {Ecurrethealth}");

        if (Ecurrethealth <= 0)
        {
            Ecurrethealth = 0;
            GameObject explosion1 = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosion1, 2);
            Debug.Log("the enemy is dead");
            Destroy(gameObject);
        }
    }
}