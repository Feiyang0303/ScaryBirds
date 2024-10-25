using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int MaxNumberofShots = 3;
    private int _usedNumberofShots;

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
