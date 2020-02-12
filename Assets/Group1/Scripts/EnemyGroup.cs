using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    private Player _player;

    public event UnityAction ListEmpty;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Attacked += OnRemoveEnemy;
    }

    private void OnDisable()
    {
        _player.Attacked -= OnRemoveEnemy;
    }

    private void OnRemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count <= 0)
            ListEmpty?.Invoke();
    }
}
