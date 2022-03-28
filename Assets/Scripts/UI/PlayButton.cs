using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    public bool deathTimer;

    public void OnPointerClick(PointerEventData eventData)
    {
        MenuManager.Instance.HandlePlayButtonOnClickEvent(deathTimer);
    }
}
