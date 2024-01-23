using UnityEngine;
using System;
using System.Collections;


public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI remaining;
    public GameObject startButton;
    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI win;


    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"{_gameManager.ScoreManager.Score}";
        remaining.text = $"{Math.Ceiling(_gameManager.TimeManager.Remaining)}";
        level.text = $"Level : {_gameManager.level}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        win.color = new Color(246, 212, 81, 0);
    }
    
    public void StopGame(bool isWin)
    {
        win.text = $"You Lost";
        if (isWin) win.text = $"You Win";
        if (_gameManager.gameOver) win.text = $"GameOver";
        win.color = new Color(246, 212, 81, 255);
        _gameManager.gameOver = false;
        startButton.SetActive(true);
    }
}