using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DistanceToEnemies))]
[RequireComponent(typeof(EnemyList))]
[RequireComponent(typeof(Slowdown))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyList _enemies;
    private DistanceToEnemies _checker;
    private Slowdown _slowdown;

    private void Awake()
    {
        _enemies = GetComponent<EnemyList>();
        _checker = GetComponent<DistanceToEnemies>();
        _slowdown = GetComponent<Slowdown>();
    }

    private void OnEnable()
    {
        _checker.EnemyChecked += OnAttack;
        _slowdown.SlowdownDone += OnSlowdownDone;
    }

    private void OnDisable()
    {
        _checker.EnemyChecked -= OnAttack;
        _slowdown.SlowdownDone -= OnSlowdownDone;
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

    private void OnSlowdownDone()
    {
        _speed /= 2;
    }
}
