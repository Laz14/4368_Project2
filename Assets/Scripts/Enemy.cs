using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    static int _maxHealth = 70;
    private int _health;
    public bool IsAlive { get; private set; }
    [SerializeField] HealthBar _healthBar;

    private void Awake()
    {
        _health = _maxHealth;
        IsAlive = true;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        float healthPercentage = (float)_health / _maxHealth;
        if (_healthBar != null)
        {
            _healthBar.SetHealthBarValue(healthPercentage);
        }

        if (_health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        IsAlive = false;
        Debug.LogError("The enemy was defeated!");
    }
}
