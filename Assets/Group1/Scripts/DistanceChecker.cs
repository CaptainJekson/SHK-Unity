using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private float _attackDistance;

    private EnemyList _enemies;

    private UnityAction<Enemy> _enemyChecked;
    public event UnityAction<Enemy> EnemyChecked 
    {
        add => _enemyChecked += value;
        remove => _enemyChecked -= value; 
    }

    private void Awake()
    {
        _enemies = GetComponent<EnemyList>();
    }

    private void Update()
    {
        СheckDistance();
    }

    private void СheckDistance()
    {
        foreach (Enemy enemy in _enemies.Enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < _attackDistance)
            {
                _enemyChecked?.Invoke(enemy);
            }
        }
    }
}
