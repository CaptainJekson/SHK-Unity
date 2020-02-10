using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
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

    private void OnEnable()
    {
        _player.Attacked += CompleteTheGame;
    }

    private void OnDisable()
    {
        _player.Attacked -= CompleteTheGame;
    }

    private void CompleteTheGame()
    {
        if(_enemies.Count <= 0)
        {
            _gameOver.SetActive(true);
            _player.gameObject.SetActive(false);
        }
    }
}
