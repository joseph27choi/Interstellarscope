using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    public int health;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    }
    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StopCoroutine(ChangeSprite());
            StartCoroutine(ChangeSprite());
        }
    }
    private IEnumerator ChangeSprite()
    {
        spriteRenderer.color = new Color(1f, 0, 0);
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = new Color(1f, 1f, 1f);


    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
