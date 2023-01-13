using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : Enemy
{
    EnemyShoot shooter;

    public override void Start()
    {
        shooter = GetComponent<EnemyShoot>();
        base.Start();
    }
    protected override IEnumerator close()
    {
        rb.velocity = Vector3.zero;
        StartCoroutine(shoot());
        while (Vector3.Distance(transform.position, player.transform.position) < 2*closeDist)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.velocity = Vector3.zero;
            yield return null;
        }
        StartCoroutine(findPlayer());
    }
    
    private IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            shooter.BeginShooting();
        }

    }
}
