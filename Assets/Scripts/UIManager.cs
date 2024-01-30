using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Serialization;


public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI remaining;
    public GameObject startButton;
    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI win;
    public TMPro.TextMeshProUGUI winScore;
    public GameObject restartButton;
    public GameObject lifeContainer;


    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        score.text = $"Score : {_gameManager.ScoreManager.Score}";
        remaining.text = $"{Math.Ceiling(_gameManager.TimeManager.Remaining)}";
        level.text = $"Level : {_gameManager.Level}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        restartButton.SetActive(false);
        win.color = new Color(246, 212, 81, 0);
        winScore.color = new Color(246, 212, 81, 0);
    }
    
    public void StopGame(bool isWin)
    {
        win.text = $"You Lost";
        if (isWin) win.text = $"You Win";
        if (_gameManager.GameOver) win.text = $"GameOver";
        win.color = new Color(246, 212, 81, 255);
        _gameManager.GameOver = false;
        if (isWin) startButton.SetActive(true);
        if (!isWin) restartButton.SetActive(true);
    }
    
    public void GameWin(int sumScore, int bestScore)
    {
        win.text = $"Albert is saved !";
        win.color = new Color(246, 212, 81, 255);
        print($"bestScore {bestScore}");
        if (sumScore > bestScore)
        {
            bestScore = sumScore;
        }
        print($"bestScore {bestScore}");

        winScore.text = $"Score : {sumScore}  Best : {bestScore}";
        winScore.color = new Color(246, 212, 81, 255);
        restartButton.SetActive(true);

    }
}