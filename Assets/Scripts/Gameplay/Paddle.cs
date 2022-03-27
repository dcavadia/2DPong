using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    float halfColliderWidth;
    float halfColliderHeight;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    bool frozen = false;
    Timer freezeTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        halfColliderWidth = bc2d.size.x / 2;
        halfColliderHeight = bc2d.size.y / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        EventManager.AddFreezerEffectListener(HandleFreezerEffectActivatedEvent);
    }

    void Update()
    {
        if (freezeTimer.Finished)
        {
            frozen = false;
            freezeTimer.Stop();
        }
    }

    void FixedUpdate()
    {
        // move for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!frozen &&
            horizontalInput != 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * GameConfiguration.PaddleMoveUnitsPerSecond *
                Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    float CalculateClampedX(float x)
    {
        // clamp left and right edges
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }
        return x;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") &&
            TopCollision(coll))
        {
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezerEffectActivatedEvent(float duration)
    {
        frozen = true;
        if (!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }
}
