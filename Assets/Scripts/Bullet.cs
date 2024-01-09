using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private GameManager _gameManager;
    public float life = 3;
 
    void Awake()
    {
        _gameManager = GameManager.Instance;
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
