using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Сhecker))]
[RequireComponent(typeof(EnemyList))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _canSlow;
    [SerializeField] private float _duration;

    private EnemyList _enemies;
    private Сhecker _checker;
    private float _сooldown;

    public event UnityAction Attacked;

    private void Awake()
    {
        _enemies = GetComponent<EnemyList>();
        _checker = GetComponent<Сhecker>();

        _сooldown = _duration;
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
        SlowdownDelay();
    }

    private void MoveControl()
    {
        float horizontalAxis = _speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalAxis = _speed * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(horizontalAxis, verticalAxis, 0);
    }

    private void SlowdownDelay()
    {
        if (_сooldown > 0)
        {
            _сooldown -= Time.deltaTime;
        }
        else if (_canSlow)
        {
            _canSlow = false;
            _speed /= 2;
        }
    }

    private void OnAttack(Enemy enemy)
    {
        enemy.Die();
        _enemies.Enemies.Remove(enemy);
        Attacked?.Invoke();
    }
}
