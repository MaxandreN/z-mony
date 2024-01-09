
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnCollected;

    public int score = 1;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected rupee");
            OnCollected?.Invoke(this);
        }
    }
}
