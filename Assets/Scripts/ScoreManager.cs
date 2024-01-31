using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    public int SumScore { get; private set; }

    private void Awake()
    {
    }

    public void Reset()
    {
        Score = 0;
    } 

    public void ResetGame()
    {
        Score = 0;
        Reset();
    } 
    
    public void AddScore(int score)
    {
        Score += score;
        SumScore += score;
    }
}