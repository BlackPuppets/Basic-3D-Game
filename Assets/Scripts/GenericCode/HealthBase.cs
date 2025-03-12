using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    [SerializeField] private float startLife = 10f;
    [SerializeField] private bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        ResetLife();
    }

    private void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
            Destroy(gameObject, 1f);
        OnKill?.Invoke(this);
    }

    public void TakeDamage(float Damage)
    {
        _currentLife -= Damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
        OnDamage?.Invoke(this);
    }
}
