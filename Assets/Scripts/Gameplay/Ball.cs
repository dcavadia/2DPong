using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    Timer moveTimer;

    Timer deathTimer;
    BallDied ballDied;

    Rigidbody2D rb2d;
    Timer speedupTimer;
    float speedupFactor;

    BallLost ballLost;

    void Start()
    {
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.AddTimerFinishedListener(HandleMoveTimerFinished);
        moveTimer.Run();

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = GameConfiguration.BallLifeSeconds;
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);
        deathTimer.Run();

        ballDied = new BallDied();
        EventManager.AddBallDiedInvoker(this);

        ballLost = new BallLost();
        EventManager.AddBallLostInvoker(this);

        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                ballLost.Invoke();
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
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

    public void AddBallLostListener(UnityAction listener)
    {
        ballLost.AddListener(listener);
    }

    public void AddBallDiedListener(UnityAction listener)
    {
        ballDied.AddListener(listener);
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

    void HandleMoveTimerFinished()
    {
        moveTimer.Stop();
        StartMoving();
    }

    void HandleDeathTimerFinished()
    {
        ballDied.Invoke();
        Destroy(gameObject);
    }

    void HandleSpeedupTimerFinished()
    {
        speedupTimer.Stop();
        rb2d.velocity *= 1 / speedupFactor;
    }
}