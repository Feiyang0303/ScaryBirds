using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _shotsTaken = 0;

    public int MaxNumberofShots = 3;
    private int _usedNumberofShots;
    
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

    // restrict number of birds to 3 per round

    private void Awake(){
        if(Instance == null){Instance = this;}
    }
    public void UseShot(){
        _usedNumberofShots++;
    }
    public bool HasEnoughShots(){
        if(_usedNumberofShots < MaxNumberofShots){return true;}
        else{return false;}
    }
}
