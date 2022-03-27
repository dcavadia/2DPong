using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;
    const string ScorePrefix = "Score: ";

    TextMeshProUGUI ballsLeftText;
    int ballsLeft;
    const string BallsLeftPrefix = "Balls Left: ";

    LastBallLost lastBallLost;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = ScorePrefix + score;

        ballsLeft = GameConfiguration.BallsPerGame;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<TextMeshProUGUI>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;

        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddBallLostListener(ReduceBallsLeft);

        lastBallLost = new LastBallLost();
        EventManager.AddLastBallLostInvoker(this);
    }

    public int Score
    {
        get { return score; }
    }

    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLost.AddListener(listener);
    }

    void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score;
    }

    void ReduceBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;
        if (ballsLeft == 0)
        {
            lastBallLost.Invoke();
        }
    }

}
