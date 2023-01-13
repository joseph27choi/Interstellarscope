using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldVisual : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerCollision collisionScript;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        collisionScript = player.GetComponent<PlayerCollision>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionScript.shield >= 2)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
        }
        else if (collisionScript.shield == 1)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.3f);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
