using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
