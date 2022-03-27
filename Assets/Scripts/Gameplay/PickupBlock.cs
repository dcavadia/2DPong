using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    PickupEffect effect;
    float duration;
    FreezerEffectActivated freezerEffectActivated;
    float speedupFactor;
    SpeedupEffectActivated speedupEffectActivated;

    void Start()
    {
        points = GameConfiguration.PickupBlockPoints;
    }

    void Update()
    {

    }

    override protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if (effect == PickupEffect.Freezer)
            {
                freezerEffectActivated.Invoke(duration);
            }
            else if (effect == PickupEffect.Speedup)
            {
                speedupEffectActivated.Invoke(duration, speedupFactor);
            }
            base.OnCollisionEnter2D(coll);
        }
    }

    public PickupEffect Effect
    {
        set
        {
            effect = value;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                duration = GameConfiguration.FreezerSeconds;
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                duration = GameConfiguration.SpeedupSeconds;
                speedupFactor = GameConfiguration.SpeedupFactor;
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupEffectInvoker(this);
            }
        }
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }
}
