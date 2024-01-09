using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI remaining;
    public GameObject startButton;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"{_gameManager.ScoreManager.Score}";
        remaining.text = $"{Math.Ceiling(_gameManager.TimeManager.Remaining)}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);

    }
    public void StopGame()
    {
        startButton.SetActive(true);
    }
}