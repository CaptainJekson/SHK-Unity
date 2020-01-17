using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class DistanceCheckerToEnemies : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private GameObject _gameOver;

    private Enemy[] _enemies;
    private Player _player;

    public int CountEnemies { get; private set; }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _enemies = FindObjectsOfType<Enemy>();
        CountEnemies = _enemies.Length - 1;
    }

    private void OnEnable()
    {
        _player.EnimesAreOver += CompleteToGame;
    }

    private void OnDisable()
    {
        _player.EnimesAreOver -= CompleteToGame;
    }

    private void Update()
    {
        СheckDistance();
    }

    private void СheckDistance()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) < _attackDistance)
            {
                _player.Attack(enemy);
                CountEnemies--;
            }
        }
    }

    private void CompleteToGame()
    {
        _gameOver.SetActive(true);
    }
}
