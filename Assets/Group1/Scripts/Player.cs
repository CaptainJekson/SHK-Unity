using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCollisions ))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bonusDuration;

    private LevelCollisions  _levelCollisions;

    public event UnityAction<Enemy> Attacked;

    private void Awake()
    {
        _levelCollisions = GetComponent<LevelCollisions>();
        ActivateBonus();
    }

    private void OnEnable()
    {
        _levelCollisions.LevelCollisionDetected += OnAttack;
    }

    private void OnDisable()
    {
        _levelCollisions.LevelCollisionDetected -= OnAttack;
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
