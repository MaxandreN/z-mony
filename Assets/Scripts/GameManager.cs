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
    public int level = 0;
    public int[] levelGoal = new int[10];
    public bool running = false;
    public bool gameOver = false;


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
        for (int i = 0; i < levelGoal.Length; i++)
        {
            levelGoal[i] = 1 + (2*i);
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
        level = 0;
        gameOver = true;
        StopGame();
    }

    private void StopGame()
    {
        running = false;
        TimeManager.StopGame();
        EnemiesManager.Reset();

        if (ScoreManager.Score >= levelGoal[level] && !gameOver)
        {
            level++;
            UIManager.StopGame(true);
        }
        else
        {
            UIManager.StopGame(false);
        }
    }

    public void StartGame()
    {
        gameOver = false;
        running = true;   
        ScoreManager?.Reset();
        TimeManager?.StartGame();
        UIManager?.StartGame();
        EnemiesManager?.StartSpawning(level);
    }
}