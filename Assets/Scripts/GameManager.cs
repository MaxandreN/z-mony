using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ScoreManager ScoreManager {get; private set; }
    public TimeManager TimeManager {get; private set; }
    public UIManager UIManager {get; private set; }
    public EnemiesManager EnemiesManager {get; private set; }
    public GameObject CurrentPlayer;
    public int Level = 0; 
    public int[] LevelGoal = new int[10];
    public bool Running = false;
    public bool GameOver = false;
    public int BestScore = 0;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        ScoreManager = GetComponent<ScoreManager>();
        TimeManager = GetComponent<TimeManager>();
        UIManager = GetComponent<UIManager>();
        EnemiesManager = GetComponent<EnemiesManager>();

        addLevelGoal();
    }

    private void addLevelGoal()
    {
        for (int i = 0; i < LevelGoal.Length; i++)
        {
            LevelGoal[i] = 4 + (2*i);
        }
    }

    private void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
        CurrentPlayer.GetComponent<Player>().OnDeath += PlayerDead;
    }

    private void TimeUpHandler()
    {
        StopGame();
    }

    private void PlayerDead()
    {
        Level = 0;
        GameOver = true;
        StopGame();
    }

    private void StopGame()
    {
        Running = false;
        TimeManager.StopGame();
        EnemiesManager.Reset();
        
        if (ScoreManager?.Score >= LevelGoal[Level] && !GameOver)
        {
            Level++;
            if (Level == 10)
            {
                UIManager.GameWin(ScoreManager.SumScore, BestScore);
            }
            else
            {
                UIManager.StopGame(true);
            }
        }
        else
        {
            UIManager.StopGame(false);
        }
    }

    public void RestartGame()
    {
        CurrentPlayer?.GetComponent<Player>().Reset();
        Level = 0;
        ScoreManager?.ResetGame();
        StartGame();
    }
    
    public void StartGame()
    {
        GameOver = false;
        Running = true;   
        ScoreManager?.Reset();
        TimeManager?.StartGame();
        UIManager?.StartGame(LevelGoal[Level]);
        EnemiesManager?.StartSpawning(Level);
    }
}