using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealthbar : MonoBehaviour
{

    Gaurdianboss_health bosshealth;
    public Image fillimage;
    public Slider Boss_healthbar;
    public Vector3 offset;
    void Start()
    {
        bosshealth = GetComponentInParent<Gaurdianboss_health>();
        // Boss_healthbar = GetComponent<Slider>();
        Boss_healthbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        Boss_healthbar.minValue = 0f;
        Boss_healthbar.maxValue = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = bosshealth.bossCurrentHealth / bosshealth.bossMaxHealth;

        Boss_healthbar.value = fillvalue;
        Boss_healthbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);

       /* if (Boss_healthbar.value <= Boss_healthbar.minValue)
        {
            fillimage.enabled = false;
        }

        if (Boss_healthbar.value > Boss_healthbar.minValue && !fillimage.enabled)
        {
            fillimage.enabled = true;
        }
       */
       

    }
}
