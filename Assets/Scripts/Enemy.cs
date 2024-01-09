
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnHit;

    [Range(1, 20)] public int score = 1;
    [Range(1, 20)] public int life = 5;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D ;
    
    private static readonly int hit = Animator.StringToHash("Hit");
    private static readonly int dead = Animator.StringToHash("Dead");

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        OnHit?.Invoke(this);
    }

    public bool Hit()
    {
        _animator.SetTrigger(hit);
        life -= 1;
        if (life > 1)
        {
            _animator.SetTrigger(dead);
            new WaitForSeconds(3f);
            return false;
        }
        return true;
    }
    
}
