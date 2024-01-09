using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private GameManager _gameManager;
    

    [Range(0f, 10f)] public float speed = 1f;
   
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gameManager = GameManager.Instance;
    }
    
    void Update()
    {
        // la direction
        Vector2 playerDirection = (_gameManager.Player.transform.position - transform.position).normalized;
        // Déplacer l'ennemi
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }
}
