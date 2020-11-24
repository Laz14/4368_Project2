using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    static int _maxHealth = 150;
    private int _health;
    public bool IsAlive { get; private set; }
    [SerializeField] HealthBar _healthBar;
    [SerializeField] string _name;

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
        }    }

    private void Kill()
    {
        IsAlive = false;
        Debug.LogError(_name + " was defeated!");
    }
}
