
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnHit;

    [Range(1, 20)] public int score = 1;
    [Range(1, 20)] public int life = 5;
    [Range(0f, 10f)] public float speed = 1f;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D ;
    private Vector2 _movement;
    private GameManager _gameManager;
    
    private static readonly int hit = Animator.StringToHash("Hit");
    private static readonly int dead = Animator.StringToHash("Dead");

    private void Awake()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        _gameManager = GameManager.Instance;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        OnHit?.Invoke(this);
    }

    public bool Hit()
    {
        life -= 1;
        if (life < 1)
        {
            _animator.SetTrigger(dead);
            return true;
        }
        else
        {
            _animator.SetTrigger(hit);
        }
        return false;
    }

    private void Update()
    {
        if (life > 1)
        {
            Move();
        }
    }
    public void Move()
    {
        // la direction
        Vector2 playerDirection = (_gameManager.Player.transform.position - transform.position).normalized;
        // Déplacer l'ennemi
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }
}
