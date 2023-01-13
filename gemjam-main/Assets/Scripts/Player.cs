using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float boostedSpeed = 10f;
    private bool boosted = false;
    private bool boostAvailable = true;
    private BoostCounter boostCounter;
    public int boosts = 3;
    public int maxBoosts = 3;

    private Vector3 movement = Vector3.zero;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boostCounter = GameObject.Find("BoostCounter").GetComponent<BoostCounter>();
        boostCounter.setBoosts(boosts);
    }

    IEnumerator Boost()
    {
        --boosts;
        boostCounter.setBoosts(boosts);
        boosted = true;
        boostAvailable = false;
        Debug.Log("Boosted!");
        yield return new WaitForSeconds(.25f);
        boosted = false;
        boostAvailable = true;
    }

    public void addBoost()
    {
        boosts  = Mathf.Max(boosts + 1, maxBoosts);
        boostCounter.setBoosts(boosts);
    }

    // Update is called once per frame
    void Update()
    {
        float moveRotation = Time.deltaTime * rotationSpeed * Input.GetAxisRaw("Horizontal") * 100;
        rb.angularVelocity -= moveRotation;
        Vector3 moveSpeed = new Vector3(0f, 1f, 0) * ((speed * (Mathf.Max(0, Input.GetAxisRaw("Vertical")) + ((boosts > 0 && boosted) ? boostedSpeed : 0))) * Time.deltaTime);

        if (Input.anyKeyDown && Input.GetAxisRaw("Fire3") > 0 && boostAvailable)
            StartCoroutine(Boost());
        rb.velocity += (Vector2) (transform.rotation * moveSpeed);
        //transform.position += movement;
    }
    

}
