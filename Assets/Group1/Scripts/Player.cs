using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private DistanceCheckerToEnemies _checkedEnemy;

    public event UnityAction EnimesAreOver;

    private void Awake()
    {
        _checkedEnemy = GetComponent<DistanceCheckerToEnemies>();
    }

    private void Update()
    {
        Move();
    }

    public void Attack(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        CountEnemies();
    }

    private void Move()
    {
        if (Input.GetButton("Vertical"))
            transform.Translate(0, _speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        if (Input.GetButton("Horizontal"))
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
