using System;
using UnityEngine;

namespace Task2
{
    public class Health
    {
        public event Action HealthOver;
        public event Action<int> ChangedHealth;

        private int _health;

        public Health(int health)
        {
            _health = health;
        }

        public void Damage(int damage)
        {
            if (damage < 0)
                return;

            _health -= damage;
            Debug.Log($"Damage {damage}");

            ChangedHealth?.Invoke(_health);

            if (_health <= 0)
            {
                _health = 0;
                Debug.Log("HealthOver");
                HealthOver?.Invoke();
            }
        }

        public void Heal(int heal)
        {
            if (heal < 0)
                return;

            _health += heal;
            Debug.Log($"Heal {heal}");
            ChangedHealth?.Invoke(_health);
        }
    }
}