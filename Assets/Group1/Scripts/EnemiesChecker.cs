using UnityEngine;
using UnityEngine.Events;

public class EnemiesChecker : MonoBehaviour
{
    [SerializeField] private float _distance;

    public event UnityAction<Enemy> EnemyChecked;

    private void OnTriggerStay2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if(enemy != null)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < _distance)
                EnemyChecked?.Invoke(enemy);
        }
    }
}
