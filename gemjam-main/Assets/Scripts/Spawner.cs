using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject nebulaOne;
    [SerializeField] GameObject nebulaTwo;
    [SerializeField] GameObject starOne;
    [SerializeField] GameObject starTwo;
    [SerializeField] GameObject starThree;
    [SerializeField] GameObject cruiser;
    [SerializeField] GameObject frigate;
    [SerializeField] GameObject scout;
    [SerializeField] GameObject bigAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject smallAsteroid;
    [SerializeField] GameObject blackHole;
    private float timeSinceEnemySpawn;
    public float spawnFrequency;
    [SerializeField] private GameObject gameCamera;
    private Transform cameraTransform;
    public float spawnFrequencyMin;
    public int cruiserThreshold;
    public int frigateThreshold;
    private float timeSinceAsteroidSpawn;
    public float asteroidSpawnFrequency;
    public int bigAsteroidThreshold;
    public int mediumAsteroidThreshold;
    private float horizontalMax = 36f;
    private float verticalMax = 20f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = gameCamera.GetComponent<Transform>();
        int blackHoleCount = Random.Range(1, 5);
        int asteroidOneCount = Random.Range(15, 25);
        int asteroidTwoCount = Random.Range(15, 25);
        int asteroidThreeCount = Random.Range(15, 25);
        int nebulaTwoCount = Random.Range(6, 16);
        int nebulaOneCount = Random.Range(6, 16);
        int starOneCount = Random.Range(40, 60);
        int starTwoCount = Random.Range(40, 60);
        int starThreeCount = Random.Range(40, 60);
        float nebulaOneRadius = nebulaTwo.GetComponent<Collider2D>().bounds.extents.x;
        float nebulaTwoRadius = nebulaTwo.GetComponent<Collider2D>().bounds.extents.x;
        float starOneRadius = starOne.GetComponent<Collider2D>().bounds.extents.x;
        float starTwoRadius = starTwo.GetComponent<Collider2D>().bounds.extents.x;
        float starThreeRadius = starThree.GetComponent<Collider2D>().bounds.extents.x;
        float asteroidOneRadius = bigAsteroid.GetComponent<Collider2D>().bounds.extents.x;
        float asteroidTwoRadius = mediumAsteroid.GetComponent<Collider2D>().bounds.extents.x;
        float asteroidThreeRadius = smallAsteroid.GetComponent<Collider2D>().bounds.extents.x;
        for (int i = 0; i < nebulaTwoCount; i++)
        {
            float x = Random.Range(-horizontalMax, horizontalMax);
            float y = Random.Range(-verticalMax, verticalMax);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, nebulaTwoRadius, LayerMask.GetMask("Nebula"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(nebulaTwo, new Vector3(x, y, 0), Quaternion.identity);
            }
                
        }
        for (int i = 0; i < nebulaOneCount; i++)
        {
            float x = Random.Range(-horizontalMax, horizontalMax);
            float y = Random.Range(-verticalMax, verticalMax);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, nebulaOneRadius, LayerMask.GetMask("Nebula"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(nebulaOne, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starOneCount; i++)
        {
            float x = Random.Range(-horizontalMax, horizontalMax);
            float y = Random.Range(-verticalMax, verticalMax);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starOneRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starOne, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starTwoCount; i++)
        {
            float x = Random.Range(-horizontalMax, horizontalMax);
            float y = Random.Range(-verticalMax, verticalMax);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starTwoRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starTwo, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starThreeCount; i++)
        {
            float x = Random.Range(-horizontalMax, horizontalMax);
            float y = Random.Range(-verticalMax, verticalMax);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starThreeRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starThree, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < asteroidOneCount; i++)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-horizontalMax, horizontalMax);
                y = Random.Range(-verticalMax, verticalMax);
            } while (((x < cameraTransform.position.x + 9) && (x > cameraTransform.position.x - 9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, asteroidOneRadius, LayerMask.GetMask("Asteroid"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(bigAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < asteroidTwoCount; i++)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-horizontalMax, horizontalMax);
                y = Random.Range(-verticalMax, verticalMax);
            } while (((x < cameraTransform.position.x + 9) && (x > cameraTransform.position.x - 9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, asteroidTwoRadius, LayerMask.GetMask("Asteroid"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(mediumAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < asteroidThreeCount; i++)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-horizontalMax, horizontalMax);
                y = Random.Range(-verticalMax, verticalMax);
            } while (((x < cameraTransform.position.x + 9) && (x > cameraTransform.position.x - 9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, asteroidThreeRadius, LayerMask.GetMask("Asteroid"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(smallAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < blackHoleCount; i++)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-horizontalMax, horizontalMax);
                y = Random.Range(-verticalMax, verticalMax);
            } while (((x < cameraTransform.position.x + 9) && (x > cameraTransform.position.x - 9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Instantiate(blackHole, new Vector3(x, y, 0), Quaternion.identity);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        timeSinceEnemySpawn += Time.deltaTime;
        if (timeSinceEnemySpawn > spawnFrequency)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-27f, 27f);
                y = Random.Range(-15f, 15f);
            } while (((x < cameraTransform.position.x+9) && (x>cameraTransform.position.x-9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            float enemyType = Random.Range(0f, 100f);
            if (enemyType > cruiserThreshold)
            {
                Instantiate(cruiser, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (enemyType > frigateThreshold)
            {
                Instantiate(frigate, new Vector3(x, y, 0), Quaternion.identity);
                cruiserThreshold--;
            }
            else
            {
                Instantiate(scout, new Vector3(x, y, 0), Quaternion.identity);
                frigateThreshold--;
            }
            spawnFrequency -= 0.1f;
            if (spawnFrequency < spawnFrequencyMin) spawnFrequency = spawnFrequencyMin;
            timeSinceEnemySpawn = 0f;
        }

        timeSinceAsteroidSpawn += Time.deltaTime;
        if (timeSinceAsteroidSpawn > asteroidSpawnFrequency)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-27f, 27f);
                y = Random.Range(-15f, 15f);
            } while (((x < cameraTransform.position.x + 9) && (x > cameraTransform.position.x - 9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            float asteroidType = Random.Range(0f, 100f);
            if (asteroidType > bigAsteroidThreshold)
            {
                Instantiate(bigAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (asteroidType > mediumAsteroidThreshold)
            {
                Instantiate(mediumAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(smallAsteroid, new Vector3(x, y, 0), Quaternion.identity);
            }
            timeSinceAsteroidSpawn = 0f;
        }
    }
}
