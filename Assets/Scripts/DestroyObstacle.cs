using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public Transform playerTransform;
    private bool hasCollidedWithPlayer = false;

    void Update()
    {
        if (transform.position.x < playerTransform.position.x && !hasCollidedWithPlayer)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollidedWithPlayer = true;
        }
    }
}
