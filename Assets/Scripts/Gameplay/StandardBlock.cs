using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite sprite0;
    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;

    void Start()
    {
        points = GameConfiguration.StandardBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = sprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = sprite1;
        }
        else
        {
            spriteRenderer.sprite = sprite2;
        }
    }

}
