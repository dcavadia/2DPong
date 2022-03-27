using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonComponent<GameManager>
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuManager.Instance.paused)
        {
            MenuManager.Instance.GoToMenu(MenuName.Pause);
        }
    }
}
