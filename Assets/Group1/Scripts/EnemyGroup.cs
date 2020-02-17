using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    private Player _player;

    public event UnityAction AllEnemiesDied;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Attacked += RemoveEnemy;
    }

    private void OnDisable()
    {
        _player.Attacked -= RemoveEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count <= 0)
            AllEnemiesDied?.Invoke();
    }
}
