using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenemyHealth : MonoBehaviour
{
    public GameObject explosion;
    SimpleFlash simpleflash;
    [SerializeField] int Emaxhealth = 5;
    public int Ecurrethealth;
    


    void Awake()
    {
        
    }
    void Start()
    {
        simpleflash = GetComponent<SimpleFlash>();
        
        Ecurrethealth = Emaxhealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemytakindamage(int amount)
    {
        Ecurrethealth -= amount;
        simpleflash.Flash();
        if (transform.position.x < charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - (GameManger.instance.knockforce * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else if (transform.position.x > charactermovement.instance.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + (GameManger.instance.knockforce * Time.deltaTime), transform.position.y, transform.position.z);
        }
        Debug.Log($"jenemy health : {Ecurrethealth}");
        if (Ecurrethealth <= 0)
        {
            Ecurrethealth = 0;
            GameObject explosion1 = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosion1, 2);
            Debug.Log("the jenemy is dead");
            Destroy(gameObject);

        }
    }
}
