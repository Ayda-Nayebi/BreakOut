using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int Score = 0; 
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int score)
    {
        if (score < 0)
        {
            print("Invalid score");
            return;
        }

        Score += score;

        SetScoreText(Score);
    }

    public void LoseScore(int score)
    {
        if (Score < 0)
        {
            return;
        }

        Score -= score;
        SetScoreText(Score);
    }
    private void SetScoreText(int score)
    {
        scoreText.SetText("Score:" + score);
    }
}
