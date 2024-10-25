using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _shotsTaken = 0;

    public int MaxNumberofShots = 3;
    private int _usedNumberofShots = 0;

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
        CheckBeforeEnd();
    }
    public void IncrementShotsTaken()
    {
        _shotsTaken++;
    }
    public int GetShotsTaken()
    {
        return _shotsTaken;
    }


    // restrict number of birds to 3 per round


    public void UseShot()
    {
        _usedNumberofShots++;
        if (_usedNumberofShots >= MaxNumberofShots)
        {
            CheckBeforeEnd();
        }
    }
    public bool HasEnoughShots()
    {
        if (_usedNumberofShots < MaxNumberofShots) { return true; }
        else { return false; }
    }
    private void CheckBeforeEnd()
    {
        if (_usedNumberofShots >= MaxNumberofShots || pumpkin.TotalPumpkins == 0)
        {
            StartCoroutine(ShowStarRatingWithDelay(2f));
        }
    }
    private IEnumerator ShowStarRatingWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("starRating");
    }
}
