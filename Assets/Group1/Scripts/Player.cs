using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DistanceChecker))]
[RequireComponent(typeof(EnemyList))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyList _enemies;
    private DistanceChecker _checker;

    private void Awake()
    {
        _enemies = GetComponent<EnemyList>();
        _checker = GetComponent<DistanceChecker>();
    }

    private void OnEnable()
    {
        _checker.EnemyChecked += OnAttack;
    }

    private void OnDisable()
    {
        _checker.EnemyChecked -= OnAttack;
    }

    private void Update()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        if (Input.GetButton("Vertical"))
            transform.Translate(0, _speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        if (Input.GetButton("Horizontal"))
            transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }

    private void OnAttack(Enemy enemy)
    {
        enemy.Die();
        _enemies.Enemies.Remove(enemy);
    }
}
