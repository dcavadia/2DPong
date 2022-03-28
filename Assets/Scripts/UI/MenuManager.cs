using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : SingletonComponent<MenuManager>
{
    GameObject pauseMenu;
    public bool paused;
    public bool deathTimer;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Help:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                pauseMenu = Instantiate(Resources.Load("PauseMenu")) as GameObject;
                paused = true;
                break;
        }
    }

    public void HandlePlayButtonOnClickEvent(bool deathTimerMode)
    {
        SceneManager.LoadScene("2DPong");
        deathTimer = deathTimerMode;
    }

    public void HandleHelpButtonOnClickEvent()
    {
        GoToMenu(MenuName.Help);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    public void HandleGoToMainMenuButtonOnClickEvent()
    {
        GoToMenu(MenuName.Main);
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        paused = false;
        Destroy(pauseMenu.gameObject);
    }

    public void HandleQuitPauseButtonOnClickEvent()
    {
        Time.timeScale = 1;
        paused = false;
        Destroy(pauseMenu.gameObject);
        GoToMenu(MenuName.Main);
    }

    public void HandleGameoverQuitButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("GameOverPanel").gameObject);
        GoToMenu(MenuName.Main);
    }

    public void HandleRestartButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("GameOverPanel").gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
