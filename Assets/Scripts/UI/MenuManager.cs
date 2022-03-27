using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : SingletonComponent<MenuManager>
{
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
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }

    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("2DPong");
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
}
