using UnityEngine;
using UnityEngine.Events;

public class LevelCollisions : MonoBehaviour
{
    [SerializeField] private float _distance;

    public event UnityAction<Enemy> EnemyСollided;

    private void OnTriggerStay2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < _distance)
                EnemyСollided?.Invoke(enemy);
        }
    }
}
