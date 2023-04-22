using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Player_health playerhealth;
    public Image fillimage;
     Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(healthbar.value <= healthbar.minValue)
        {
            fillimage.enabled = false;
        }

        if(healthbar.value >healthbar.minValue && !fillimage.enabled)
        {
            fillimage.enabled = true;
        }
        float fillvalue = playerhealth.currethealth / playerhealth.maxhealth;
        healthbar.value = fillvalue;
    }
}
