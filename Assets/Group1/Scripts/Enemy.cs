using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Awake()
    {
        _target = GetRandomPoint();
    }

    private void Update()
    {
        MoveToRandomPoint();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void MoveToRandomPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = GetRandomPoint();
    }

    private Vector3 GetRandomPoint()
    {
        return Random.insideUnitCircle * _radius;
    }
}
