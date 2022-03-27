using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI messageText;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void SetScore(int score)
    {
        messageText.text = "Game Over!\n\nScore: " + score;
    }

    public void HandleQuitButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.Instance.GoToMenu(MenuName.Main);
    }
}
