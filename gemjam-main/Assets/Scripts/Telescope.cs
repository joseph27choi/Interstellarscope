using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    private float scale = 2.5f;
    CircleCollider2D mspaint;
    Camera cam;
    private float radius;
    bool allowed = true;

    // Start is called before the first frame update
    void Start()
    {
        cam = (Camera)(FindObjectOfType(typeof(Camera)));
        mspaint = GetComponent<CircleCollider2D>();
        mspaint.enabled = false; //sadge
        radius = mspaint.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowed)
        {
            transform.position = (Vector2)(cam.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.anyKeyDown && Input.GetAxisRaw("Fire1") > 0 && allowed)
        {
            allowed = false;
            var circles = Physics2D.OverlapCircleAll(transform.position, mspaint.radius);
            foreach (Collider2D c in circles)
            {
                var eng = c.gameObject.GetComponent<Enlargible>();
                if (eng != null) StartCoroutine(eng.Enlarge(transform.position));  
            }
            StartCoroutine(expand());
        }
    }

    IEnumerator expand()
    {
        float expandFactor = Mathf.Pow(scale, 1f / 60f);
        for (int i = 0; i < 60; i++)
        {
            transform.localScale *= expandFactor; 
            yield return new WaitForSeconds(0.02f);
        }
        allowed = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
