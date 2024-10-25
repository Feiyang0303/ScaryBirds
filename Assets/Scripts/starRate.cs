using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarRating : MonoBehaviour
{
    [SerializeField] private GameObject[] brightstars;
    [SerializeField] private GameObject[] greystars;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI shotsText;
    private int maxStars = 3;

    private void Start()
    {
        int finalScore = Points.instance.GetScore();
        int shotsTaken = GameManager.instance.GetShotsTaken();
        DisplayPerformance(finalScore, shotsTaken);
        int starRating = CalculateStars(finalScore);
        DisplayStars(starRating);
    }

    private int CalculateStars(int score)
    {
        if (score >= 40)
            return 3;
        else if (score >= 30 && score < 40)
            return 2;
        else if (score >= 10 && score < 30)
            return 1;
        return 0;
    }

    private void DisplayStars(int starCount)
    {
        for (int i = 0; i < maxStars; i++)
        {
            brightstars[i].SetActive(i < starCount);
            greystars[i].SetActive(i >= starCount);
        }
    }
    private void DisplayPerformance(int score, int shots)
    {
        scoreText.text = "Score: " + score;
        shotsText.text = "Shots Taken: " + shots;
    }

}
