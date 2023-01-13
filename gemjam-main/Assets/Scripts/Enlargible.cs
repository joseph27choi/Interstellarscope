using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enlargible : MonoBehaviour
{
    Rigidbody2D rb;
    AsteroidCollision ast;
    public bool enlarged = false;
    [SerializeField] int enlargesLeft = 1;
    private float scale = 2.5f;
    private float targetVelocity = 5f;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ast = GetComponent<AsteroidCollision>();
        cam = (Camera)(FindObjectOfType(typeof(Camera)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Enlarge(Vector3 center)
    {
        if (--enlargesLeft >= 0)
        {
            enlarged = true;
            ast.health *= 2;
            rb.velocity = Vector3.zero;
            float expandFactor = Mathf.Pow(scale, 1f / 60f);
            Vector3 moveFactor = (scale - 1) * (transform.position - center) / 60f;
            var vAng = rb.angularVelocity;
            rb.angularVelocity = 0;
            for (int i = 0; i < 60; i++)
            {
                rb.velocity = Vector3.zero;
                transform.localScale *= expandFactor;
                transform.position += moveFactor;
                yield return new WaitForSeconds(0.02f);
            }

            Vector3 direction = (Vector3)(Vector2)(cam.ScreenToWorldPoint(Input.mousePosition)) - transform.position;
            var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.angularVelocity = vAng;
            rb.velocity = (Quaternion.Euler(0, 0, rotation) * new Vector3(0f, 1f, 0) * targetVelocity);
        }
    }
}
