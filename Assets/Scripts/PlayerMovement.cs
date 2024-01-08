using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    [Range(5f, 30f)] public float speed = 5f;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(horizontal, vertical).normalized;
        _animator.SetFloat(Horizontal, horizontal);
        _animator.SetFloat(Vertical, vertical);
        _animator.SetFloat(Speed, _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement * speed;
    }
}