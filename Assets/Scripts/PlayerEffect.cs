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
        // 计算每拍的时间间隔
        beatInterval = 60f / 85f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 当达到或超过一拍的时间时
        if (timer >= beatInterval)
        {
            // 重置计时器
            timer -= beatInterval;

            // 如果粒子系统正在播放，则停止它；如果它停止了，则播放它。
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
