using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public GameObject player;

    //private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    //private static readonly int Vertical = Animator.StringToHash("Vertical");
    //private static readonly int Speed = Animator.StringToHash("Speed");

    [Range(0f, 10f)] public float speed = 1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        var moveDirection = (player.transform.position - transform.position).normalized* speed;
        _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    
    void Update()
    {
        var moveDirection = (player.transform.position - transform.position).normalized* speed;
        _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }
}
