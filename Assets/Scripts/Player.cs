using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnDeath;
    public int fullLife = 5;
    public int life;
    
    private GameManager _gameManager;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    [Range(5f, 30f)] public float speed = 5f;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        life = fullLife;
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        
        if (!_gameManager.running)
        {
            horizontal = 0;
            vertical = 0;
        }

        _movement = new Vector2(horizontal, vertical).normalized;
        _animator.SetFloat(Horizontal, horizontal);
        _animator.SetFloat(Vertical, vertical);
        _animator.SetFloat(Speed, _movement.sqrMagnitude);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Hit();
        }
    }
    
    public bool Hit()
    {
        life -= 1;
        print("hit !!");
        if (life < 1)
        {
            print("dead");
            OnDeath?.Invoke();
            life = fullLife;
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement * speed;
    }
}