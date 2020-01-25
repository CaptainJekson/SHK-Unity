using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceToEnemies : MonoBehaviour
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

    private void OnTriggerStay2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if (Vector3.Distance(transform.position, enemy.transform.position) < _attackDistance)
            _enemyChecked?.Invoke(enemy);
    }
}
