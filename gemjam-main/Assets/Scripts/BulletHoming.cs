using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 1f;
    public float lifetime = 5f;
    public LayerMask solidLayers;
    [SerializeField] GameObject bulletExplosion;
    public float distance;
    private Vector2 svelocity;
    public float rotationSpeed;
    protected GameObject player;
    protected PlayerCollision ihatedarrenjia;

    private void Start()
    {
        player = GameObject.Find("PlayerShip");
        ihatedarrenjia = player.GetComponent<PlayerCollision>();
        Invoke("DestroyBullet", lifetime);
    }
    // Update is called once per frame
    private void Update()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, solidLayers);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerCollision>().TakeDamage(1);
            }
            if (hitInfo.collider.CompareTag("Asteroid"))
            {
                hitInfo.collider.GetComponent<AsteroidCollision>().TakeDamage(1);
            }
            DestroyBullet();
        }
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90f;
        float magnitude = direction.magnitude;
        transform.Translate((direction/magnitude)*bulletSpeed * Time.deltaTime, Space.World);
        transform.rotation=(Quaternion.Euler(0, 0, angle));
        
    }

    private void DestroyBullet()
    {
        Instantiate(bulletExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void PassShipVelocity(Vector2 velocity)
    {
        
    }
}
