using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected int points;
    PointsAdded pointsAdded;

    BlockDestroyed blockDestroyed;

    virtual protected void Start()
    {
        pointsAdded = new PointsAdded();
        EventManager.AddPointsAddedInvoker(this);

        blockDestroyed = new BlockDestroyed();
        EventManager.AddBlockDestroyedInvoker(this);
    }

    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            pointsAdded.Invoke(points);
            blockDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAdded.AddListener(listener);
    }

    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyed.AddListener(listener);
    }
}
