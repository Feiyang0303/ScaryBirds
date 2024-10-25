using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkin : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _damageThreshhold = 1f;
    private float _currentHelath;
    [SerializeField] private int _pointsForDestruction = 10;
    public static int TotalPumpkins { get; private set; }

    public void Awake()
    {
        _currentHelath = _maxHealth;
        TotalPumpkins++;
    }
    public void DamangePumpkin(float damageAmount)
    {
        if (damageAmount <= 0) return;
        _currentHelath -= damageAmount;
        if (_currentHelath <= 0f)
        {
            Die();
        }

    }
    private void Die()
    {
        Points.instance.AddScore(_pointsForDestruction);
        Destroy(gameObject);
        TotalPumpkins--;
        if (TotalPumpkins <= 0)
        {
            GameManager.instance.AllPumpkinsDestroyed();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude;
        if (impactVelocity > _damageThreshhold)
        {
            DamangePumpkin(impactVelocity);
        }
    }
}
