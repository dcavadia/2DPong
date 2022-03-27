using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Timer moveTimer;

    Timer deathTimer;

    void Start()
    {
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = GameConfiguration.BallLifeSeconds;
        deathTimer.Run();
    }

    void Update()
    {
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
        }
        if (deathTimer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
                HUD.ReduceBallsLeft();
            }
            Destroy(gameObject);
        }
    }

    void StartMoving()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            GameConfiguration.BallImpulseForce * Mathf.Cos(angle),
            GameConfiguration.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }
}