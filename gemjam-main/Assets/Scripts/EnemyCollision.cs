using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Player player;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public int health;
    [SerializeField] GameObject engineEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("PlayerShip").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(1);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health <= 0) return;
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Enlargible e = collision.gameObject.GetComponent<Enlargible>();
            if (e != null && e.enlarged) player.addBoost();
            int min = collision.gameObject.GetComponent<AsteroidCollision>().health;
            if (health < min)
            {
                min = health;
            }
            
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(min);
            TakeDamage(min);
        }

    }
    private void Die()
    {
        Destroy(engineEffect);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;
        
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("damage");
        health-=damage;
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
