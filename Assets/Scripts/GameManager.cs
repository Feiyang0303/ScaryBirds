using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _shotsTaken = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AllPumpkinsDestroyed()
    {
        ShowStarRating();
    }
    public void IncrementShotsTaken()
    {
        _shotsTaken++;
    }
    public int GetShotsTaken()
    {
        return _shotsTaken;
    }

    private void ShowStarRating()
    {
        SceneManager.LoadScene("starRating");

    }
}