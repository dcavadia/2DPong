using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    //Spawn support
    Vector2 spawnLocation = new Vector2(0, -1.5f);
    Timer spawnTimer;
    float spawnRange;

    //Collision-free support
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    void Start()
    {
        //Spawn and destroy ball to calculate
        //Spawn location min and max
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        //Initialize and start spawn timer
        spawnRange = GameConfiguration.MaxSpawnSeconds -
            GameConfiguration.MinSpawnSeconds;
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();

        //Spawn first ball in game
        SpawnBall();
    }

    void Update()
    {
        if (spawnTimer.Finished)
        {
            //Don't stack with a spawn still pending
            retrySpawn = false;
            SpawnBall();
            spawnTimer.Duration = GetSpawnDelay();
            spawnTimer.Run();
        }

        //Try again if spawn still pending
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        //Make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }

    float GetSpawnDelay()
    {
        return GameConfiguration.MinSpawnSeconds +
            Random.value * spawnRange;
    }
}
