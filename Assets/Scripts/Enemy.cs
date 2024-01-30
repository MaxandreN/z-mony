
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnHit;

    [Range(1, 20)] public int score = 1;
    [Range(1, 20)] public int life = 4;
    [Range(0f, 10f)] public float speed = 1.5f;


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
        if (other.gameObject.GetComponent<Player>() || other.gameObject.GetComponent<Bullet>())
        {
            OnHit?.Invoke(this);
        }
    }

    public bool Hit()
    {
        life -= 1;
        if (life < 1)
        {
            _animator.SetTrigger(dead);
            WaitSec();
            return true;
        }
        else
        {
            _animator.SetTrigger(hit);
        }
        return false;
    }

    private IEnumerable<WaitForSeconds> WaitSec()
    {
        yield return new WaitForSeconds(2f);
        
    }

    private void Update()
    {
        if (life >= 1)
        {
            Move();
        }

        switch (_gameManager.Level)
        {
            case 6:
                speed = 1.75f;
                break;
            case 7:
                speed = 2f;
                break;
            case 8:
                speed = 2.25f;
                break;
            case 9:
                speed = 2.5f;
                break;
        }
    }
    public void Move()
    {
        // la direction
        Vector2 playerDirection = (_gameManager.CurrentPlayer.transform.position - transform.position).normalized;
        // Déplacer l'ennemi
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }
}
