using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScout : Enemy
{
    EnemyShoot shooter;

    public override void Start()
    {
        shooter = GetComponent<EnemyShoot>();
        base.Start();
    }
    protected override IEnumerator far()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            shooter.BeginShooting();
        }
    }

}
