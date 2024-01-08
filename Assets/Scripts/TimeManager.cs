using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public int duration = 20;
    public float Remaining { get; private set; }
    private bool _running = false;

    public event Action OnTimeUp;

    public void Reset()
    {
        Remaining = duration;
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        Reset();
        _running = true;
    }

    public void StopGame()
    {
        _running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_running) return;

        Remaining -= Time.deltaTime; 

        if (Remaining <= 0)
        {
            Remaining = 0;
            StartGame();
            OnTimeUp?.Invoke();
        }
    }
}