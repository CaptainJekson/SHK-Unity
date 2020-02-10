using UnityEngine;
using UnityEngine.Events;

public class Сhecker : MonoBehaviour
{
    [SerializeField] private float _attackDistance;

    public event UnityAction<Enemy> EnemyChecked;

    private void OnTriggerStay2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        bool IsEnemy = Vector3.Distance(transform.position, enemy.transform.position) < _attackDistance;

        if (IsEnemy)
            EnemyChecked?.Invoke(enemy);
    }
}
