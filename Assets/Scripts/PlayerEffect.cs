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
    
    public bool IsPerfectTiming()
    {
        return (timer >= 0 && timer <= 0.3f) || (timer >= beatInterval - 0.3f && timer < beatInterval);
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
