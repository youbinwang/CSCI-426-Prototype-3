using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private float beatInterval;
    private float timer;

    void Start()
    {
    
        beatInterval = 60f / 85f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= beatInterval)
        {
           
            timer -= beatInterval;

            
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
            else
            {
                particleSystem.Play();
            }
        }
    }
}
