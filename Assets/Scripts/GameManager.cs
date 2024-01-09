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
    public GameObject Player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        ScoreManager = GetComponent<ScoreManager>();
        TimeManager = GetComponent<TimeManager>();
        UIManager = GetComponent<UIManager>();
        EnemiesManager = GetComponent<EnemiesManager>();
    }

    private void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
    }

    private void TimeUpHandler()
    {
        StopGame();
    }

    private void StopGame()
    {
        UIManager.StopGame();
        TimeManager.StopGame();
        EnemiesManager.Reset();
    }

    public void StartGame()
    {
        ScoreManager?.Reset();
        TimeManager?.StartGame();
        UIManager?.StartGame();
        EnemiesManager?.StartSpawning();
    }
}