using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldForce : MonoBehaviour
{
    [SerializeField] private float worldForceMagnitude;
    [SerializeField] public Vector2 forceDirection;
    private Vector2 appliedForce;
    [SerializeField] private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity += (Vector2) (forceDirection * worldForceMagnitude * Time.deltaTime);
        }
    }
}
