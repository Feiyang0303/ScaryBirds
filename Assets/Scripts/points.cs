using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public static Points instance;
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddScore(int points)
    {
        if (points > 0)
        {
            score += points;
            UpdateScoreText();
        }

    }

    //Getter
    public int GetScore()
    {
        return score;
    }


    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Points: " + score.ToString();
        }

    }
}
