using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlackHole : MonoBehaviour
{
    public float gravitationalConstant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 direction = transform.position- collision.gameObject.GetComponent<Transform>().position;
        
        float magnitude = direction.magnitude;
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity += (Vector2)(Time.deltaTime*gravitationalConstant *direction/((float) Math.Pow(magnitude,3)));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(999);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyCollision>().TakeDamage(999);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerCollision>().TakeDamage(999);
        }
    }
}
