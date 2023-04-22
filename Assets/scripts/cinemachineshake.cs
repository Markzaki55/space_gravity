using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineshake : MonoBehaviour
{
    public static cinemachineshake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachinevirtulcam;
    private float Shaketimer;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cinemachinevirtulcam = GetComponent<CinemachineVirtualCamera>();
        
    }

    public void ShakeCamera(float intensty,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachinevirtulcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensty;
        Shaketimer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Shaketimer >0)
        {
            Shaketimer -= Time.deltaTime;
            if(Shaketimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachinevirtulcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                
            }
        }


    }
}
