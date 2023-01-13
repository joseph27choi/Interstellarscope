using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] shootPoint;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject lastBullet;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        print(anim);
    }

    private void Update()
    {
        
    }

    public void BeginShooting()
    {
        anim.SetInteger("state", 1);

    }
    private void Shoot(int gun)
    {
        lastBullet = Instantiate(bullet, shootPoint[gun].position, transform.rotation);
        lastBullet.GetComponent<Bullet>().PassShipVelocity(rb.velocity);
    }
    private void EndShooting()
    {
        anim.SetInteger("state", 0);
    }
}
