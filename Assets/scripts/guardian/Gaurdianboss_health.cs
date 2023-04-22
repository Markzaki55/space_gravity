
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Gaurdianboss_health : MonoBehaviour
{

    public UnityEngine.UI.Image healthbar;

    public float bossMaxHealth = 50f; 
    public float bossCurrentHealth;

    public float healRate = 10f; 
    private float timeSinceLastDamage; 

    public BoxCollider2D nextSceneTrigger;
    public Animator bossAnimator;
    private SimpleFlash simpleFlash;

    void Awake()
    {
        bossCurrentHealth = bossMaxHealth;
    }

    void Start()
    {
        nextSceneTrigger = GameObject.FindGameObjectWithTag("NextScene").GetComponent<BoxCollider2D>();
        bossAnimator = GetComponent<Animator>();
        simpleFlash = GetComponent<SimpleFlash>();

        timeSinceLastDamage = Time.time; 
    }

    void Update()
    {
       
        BossHeal();


    }

    public void BossDamage(int amount)
    {
        bossCurrentHealth -= amount;

        
        simpleFlash.Flash();

        Debug.Log($"Boss health : {bossCurrentHealth}");

        if (bossCurrentHealth <= 0)
        {
            bossCurrentHealth = 0;
            Debug.Log("The Boss is dead");

            // Activate the next scene trigger
            nextSceneTrigger.isTrigger = true;

            // Play dead animation
            bossAnimator.SetTrigger("Bossisdead");

            
            Destroy(gameObject, 5f);
        }

        
        timeSinceLastDamage = Time.time;
    }
    public void BossHeal()
    {
        if (Time.time - timeSinceLastDamage >= 2f)
        {
            bossCurrentHealth += healRate * Time.deltaTime;
            bossCurrentHealth = Mathf.Clamp(bossCurrentHealth, 0f, bossMaxHealth);
        }
        if (Time.time - timeSinceLastDamage >= 2f)
        {
            healthbar.color = Color.green;
        }
        else
        {
            healthbar.color = Color.red;
        }
    }
}