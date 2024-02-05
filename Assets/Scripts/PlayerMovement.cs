using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5f;
    private Rigidbody2D rb;

    public ParticleSystem dust;
    public GameObject dustSystem;
    public SpriteRenderer circleSpriteRenderer;

    public TextMeshProUGUI endText;
    public GameObject end;
    public GameObject restart;
    public GameObject bgm;
    public GameObject ringParticle;
    public ParticleSystem endParticle;

    public AudioSource endAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed != 0 && !dust.isPlaying)
        {
            dust.Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

    //Player Died
    void PlayerDied()
    {
        Debug.Log("You Die!");
        dustSystem.SetActive(false);
        ringParticle.SetActive(false);
        
        circleSpriteRenderer.enabled = false;
        endAudio.Play();
        endParticle.Play();
        
        StartCoroutine(PauseGameAfterDelay(5f));
        
        end.SetActive(true);
        endText.text = ("YOU LOSE!");
        bgm.SetActive(false);
        restart.SetActive(true);
    }
    
    IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 0;
    }
}
