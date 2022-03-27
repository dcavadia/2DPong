using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUD : MonoBehaviour
{
    static TextMeshProUGUI scoreText;
    static int score = 0;
    const string ScorePrefix = "Score: ";

    static TextMeshProUGUI ballsLeftText;
    static int ballsLeft;
    const string BallsLeftPrefix = "Balls Left: ";

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = ScorePrefix + score;

        ballsLeft = GameConfiguration.BallsPerGame;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<TextMeshProUGUI>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;
    }

    public static void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score;
    }

    public static void ReduceBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;
    }

}
