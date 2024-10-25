using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarRating : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI shotsText;
    private int maxStars = 3;

    private void Start()
    {
        int finalScore = Points.instance.GetScore();
        int shotsTaken = GameManager.instance.GetShotsTaken();
        DisplayPerformance(finalScore, shotsTaken);
        int starRating = CalculateStars(finalScore, shotsTaken);
        DisplayStars(starRating);
    }

    private int CalculateStars(int score, int shots)
    {
        float scoreRatio = (float)score / shots;
        if (scoreRatio >= 30)
            return 3;
        else if (scoreRatio >= 20)
            return 2;
        else if (scoreRatio >= 10)
            return 1;
        return 0;
    }

    private void DisplayStars(int starCount)
    {
        for (int i = 0; i < maxStars; i++)
        {
            stars[i].SetActive(i < starCount);
        }
    }
    private void DisplayPerformance(int score, int shots)
    {
        scoreText.text = "Score: " + score;
        shotsText.text = "Shots Taken: " + shots;
    }

}
