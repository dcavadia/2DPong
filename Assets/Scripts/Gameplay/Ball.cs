using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Timer moveTimer;

    Timer deathTimer;

    Rigidbody2D rb2d;
    Timer speedupTimer;
    float speedupFactor;

    void Start()
    {
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = GameConfiguration.BallLifeSeconds;
        deathTimer.Run();

        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
        rb2d = GetComponent<Rigidbody2D>();
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

        if (speedupTimer.Finished)
        {
            speedupTimer.Stop();
            rb2d.velocity *= 1 / speedupFactor;
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

        if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.SpeedupEffectSecondsLeft,
                EffectUtils.SpeedupFactor);
            force *= speedupFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        if (!speedupTimer.Running)
        {
            StartSpeedupEffect(duration, speedupFactor);
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }
}