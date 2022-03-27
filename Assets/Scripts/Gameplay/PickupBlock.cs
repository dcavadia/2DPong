using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    PickupEffect effect;

    void Start()
    {
        points = GameConfiguration.PickupBlockPoints;
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
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
            }
        }
    }
}
