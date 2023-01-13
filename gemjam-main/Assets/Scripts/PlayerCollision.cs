using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public int health = 4;
    [SerializeField] GameObject engine;
    [SerializeField] GameObject engineEffect;
    [SerializeField] GameObject canvasObject;
    [SerializeField] GameObject timerText;
    public int shield = 2;
    private int maxshield = 2;
    private float shieldRecovery;
    private float shieldRechargeRate=4f;
    // Start is called before the first frame update
    void Start()
    {
        canvasObject.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        shieldRecovery += Time.deltaTime;
        if (shield >= maxshield)
        {
            shieldRecovery = 0;
        }
        if (shieldRecovery > shieldRechargeRate)
        {
            shield++;
            shieldRecovery = 0;
        }
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
            int min = collision.gameObject.GetComponent<AsteroidCollision>().health;
            if (health < min)
            {
                min = health;
            }
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(min);
            TakeDamage(min);
            
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            int min = collision.gameObject.GetComponent<EnemyCollision>().health;
            if (health < min)
            {
                min = health;
            }
            collision.gameObject.GetComponent<EnemyCollision>().TakeDamage(min);
            TakeDamage(min);
            
        }
    }
    private void Die()
    {
        Destroy(engine);
        Destroy(engineEffect);
        timerText.GetComponent<TimeCount>().PassTime();
        timerText.SetActive(false);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;
        

    }
    public void TakeDamage(int damage)
    {
        if (damage <= shield)
        {
            shield -= damage;
        }
        else
        {
            damage -= shield;
            shield = 0;
            health -= damage;
        }
        
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
        anim.SetInteger("health", health);
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = new Color(1f, 1f, 1f);
        

    }
    private void DisplayCanvas()
    {
        
        canvasObject.SetActive(true);
        
    }
    
}
