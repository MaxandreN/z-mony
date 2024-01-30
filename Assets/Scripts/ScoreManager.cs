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
        SumScore = 0;
    } 

    public void AddScore(int score)
    {
        Score += score;
        SumScore += score;
    }
}