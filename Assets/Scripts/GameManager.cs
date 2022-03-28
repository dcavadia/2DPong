using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonComponent<GameManager>
{
    public bool deathTimer;

    void Start()
    {
        deathTimer = MenuManager.Instance.deathTimer;
        EventManager.AddLastBallLostListener(HandleLastBallLost);
        EventManager.AddBlockDestroyedListener(HandleBlockDestroyed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.GoToMenu(MenuName.Pause);
        }
    }

    void HandleLastBallLost()
    {
        EndGame();
    }

    void HandleBlockDestroyed()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameObject gameOverMessage = Instantiate(Resources.Load("GameOverPanel")) as GameObject;
        GameOverPanel gameOverMessageScript = gameOverMessage.GetComponent<GameOverPanel>();
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        HUD hudScript = hud.GetComponent<HUD>();
        gameOverMessageScript.SetScore(hudScript.Score);
    }
}
