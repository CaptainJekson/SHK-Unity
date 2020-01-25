using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slowdown : MonoBehaviour
{
    [SerializeField] private bool _canSlow;
    [SerializeField] private float _duration;

    private float _сooldown;

    private UnityAction _slowdownDone;
    public event UnityAction SlowdownDone
    {
        add => _slowdownDone += value;
        remove => _slowdownDone -= value;
    }

    private void Awake()
    {
        _сooldown = _duration;
    }

    private void Update()
    {
        if (_сooldown > 0)
        {
            _сooldown -= Time.deltaTime;
        }
        else if(_canSlow)
        {
            _slowdownDone?.Invoke();
            _canSlow = false;
        }
    }
}
