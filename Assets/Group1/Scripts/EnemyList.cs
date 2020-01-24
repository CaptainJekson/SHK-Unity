using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private GameObject _gameOver;

    private Player _player;

    public List<Enemy> Enemies => _enemies;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_enemies.Count <= 0)
            CompleteTheGame();
    }

    private void CompleteTheGame()
    {
        _player.enabled = false;
        _gameOver.SetActive(true);
    }
}
