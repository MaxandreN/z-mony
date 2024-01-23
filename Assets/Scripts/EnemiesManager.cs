using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private GameManager _gameManager;

    public Transform container;
    public Transform spawner;
    public Enemy enemyPrefab;
    public float[] delays = new float[10];
    public AudioSource source;

    private List<Enemy> _enemies = new List<Enemy>();
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        addLevels();
    }

    public void addLevels()
    {
        for (int i = 0; i < delays.Length; i++)
        {
            delays[i] = 5f - (0.2f*i);
        }
    }
    
    public void Reset()
    {
        StopSpawning();

        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            RemoveEnemy(_enemies[i]);
        }
        _enemies.Clear();
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.OnHit -= EnemyHitHandler;
        Destroy(enemy.gameObject);
    }

    public void StartSpawning(int level)
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine(level));
    }

    private void StopSpawning()
    {
        if (_spawnCoroutine == null) return;

        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;
    }

    private IEnumerator SpawnCoroutine(int level)
    {
        Spawn();
        yield return new WaitForSeconds(delays[level]);
        StartSpawning(level);
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(enemyPrefab, spawner.position, Quaternion.identity, container);
        enemy.OnHit += EnemyHitHandler;
        _enemies.Add(enemy);
    }

    private void EnemyHitHandler(Enemy enemy)
    {
        if (enemy.Hit())
        {
            _gameManager.ScoreManager.AddScore(enemy.score);
            RemoveEnemy(enemy);
        }

    }
}
