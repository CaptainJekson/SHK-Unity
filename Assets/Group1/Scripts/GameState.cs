using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private EnemyList _enemyList;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _enemyList.ListEmpty += OnGameOver;
    }

    private void OnDisable()
    {
        _enemyList.ListEmpty -= OnGameOver;
    }

    private void OnGameOver()
    {
        _gameOver.SetActive(true);
        _player.gameObject.SetActive(false);
    }
}
