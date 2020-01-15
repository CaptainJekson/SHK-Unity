using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction EnimesAreOver;

    [SerializeField] private float _speed;

    private EnemyCheck _checkedEnemy;

    private void Awake()
    {
        _checkedEnemy = GetComponent<EnemyCheck>();
    }

    private void Update()
    {
        Move(Input.GetButton("Vertical"), Input.GetButton("Horizontal"));
    }

    public void ToAttack(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        CountEnemies();
    }

    private void Move(bool verticalControl, bool horizontalControl)
    {
        if (verticalControl)
            transform.Translate(0, _speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        if (horizontalControl)
            transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }

    private void CountEnemies()
    {
        if (_checkedEnemy.CountEnemies <= 0)
        {
            EnimesAreOver?.Invoke();
            enabled = false;
        }
    }
}
