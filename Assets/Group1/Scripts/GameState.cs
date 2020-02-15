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
        _enemyGroup.AllEnemiesDied += GameOver;
    }

    private void OnDisable()
    {
        _enemyGroup.AllEnemiesDied -= GameOver;
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        _player.gameObject.SetActive(false);
    }
}
