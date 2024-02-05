using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollect : MonoBehaviour
{
    public ColorSwitch colorSwitch;
    public ColorSwitch.ColorState colorToActivate;

    public AudioSource collectAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colorSwitch.ActivateColor(colorToActivate);
            collectAudio.Play();
            Destroy(gameObject);
        }
    }
}
