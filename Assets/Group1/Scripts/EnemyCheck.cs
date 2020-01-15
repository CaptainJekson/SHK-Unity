using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class EnemyCheck : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private GameObject _gameOver;

    private Enemy[] _enemies;

    private Player _player;

    public int CountEnemies { get; private set; }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Start()
    {
        CountEnemies = _enemies.Length - 1;
    }

    private void OnEnable()
    {
        _player.EnimesAreOver += EndGame;
    }

    private void Update()
    {
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) < _distance)
            {
                _player.ToAttack(enemy);
                CountEnemies--;
            }
        }
    }

    private void EndGame()
    {
        _gameOver.SetActive(true);
    }

    private void OnDisable()
    {
        _player.EnimesAreOver -= EndGame;
    }
}
