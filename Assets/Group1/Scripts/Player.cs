using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemiesChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bonusDuration;

    private EnemiesChecker _checker;

    public event UnityAction<Enemy> Attacked;

    private void Awake()
    {
        _checker = GetComponent<EnemiesChecker>();
        ActivateBonus();
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
        ControlMoving();
    }

    private void ControlMoving()
    {
        transform.Translate(GetSpeedAxis("Horizontal"), GetSpeedAxis("Vertical"), 0);
    }

    private float GetSpeedAxis(string axisName)
    {
        return _speed * Input.GetAxis(axisName) * Time.deltaTime;
    }

    private void OnAttack(Enemy enemy)
    {
        enemy.Die();
        Attacked?.Invoke(enemy);
    }

    private void ActivateBonus()
    {
        _speed *= 2;
        StartCoroutine(DeactivateBonus());
    }

    private IEnumerator DeactivateBonus()
    {
        yield return new WaitForSeconds(_bonusDuration);
        _speed /= 2;
    }
}
