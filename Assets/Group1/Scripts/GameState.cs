using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private EnemyGroup _enemyGroup;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _enemyGroup.ListEmpty += OnGameOver;
    }

    private void OnDisable()
    {
        _enemyGroup.ListEmpty -= OnGameOver;
    }

    private void OnGameOver()
    {
        _gameOver.SetActive(true);
        _player.gameObject.SetActive(false);
    }
}
