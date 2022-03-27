using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    GameObject prefabPickupBlock;

    void Start()
    {
        Instantiate(prefabPaddle);

        //Retrieve block size
        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        //Calculate blocks per row and make sure left block position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        //Add rows of blocks
        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blocksPerRow; column++)
            {
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }

            //Move to next row
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }
    }

    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        if (randomBlockType < GameConfiguration.StandardBlockProbability)
        {
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
        }
        else if (randomBlockType <
                 (GameConfiguration.StandardBlockProbability + GameConfiguration.BonusBlockProbability))
        {
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        }
        else
        {
            // pickup block selected
            GameObject pickupBlock = Instantiate(prefabPickupBlock, position, Quaternion.identity);
            PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();

            // set pickup effect
            float freezerThreshold = GameConfiguration.StandardBlockProbability +
                GameConfiguration.BonusBlockProbability +
                GameConfiguration.FreezerBlockProbability;
            if (randomBlockType < freezerThreshold)
            {
                pickupBlockScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                pickupBlockScript.Effect = PickupEffect.Speedup;
            }
        }
    }
}
