using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        magnitude = Random.Range(0f, 3f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (direction*magnitude);
    }


}
