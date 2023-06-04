using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour,Idamageable
{
    
     public GameObject explosion;
    charactermovement charmove;
    Animator anim;
    [SerializeField] public float maxhealth = 20;
     
    public float currethealth;
    public static Player_health instance;


    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currethealth = maxhealth;
        anim = GetComponent<Animator>();
        charmove = GetComponent<charactermovement>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Takedamage(int amount)
    {
        currethealth -= amount;
       
        Debug.Log($"your health : {currethealth}");
        if (currethealth <= 0)
        {
            GameManger.instance.OnGameOver();
            currethealth = 0;
            charmove.enabled = false;
            anim.SetTrigger("isdead");
            GameObject explosion1 = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosion1, 2);


            // play a tryagain scene

            Debug.Log("you are dead");
            
        }
    }
}
