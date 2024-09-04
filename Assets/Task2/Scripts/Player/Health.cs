using System;
using UnityEngine;

namespace Task2
{
    public class Health
    {
        public event Action HealthOver;
        public event Action<float> ChangedHealth;

        private float _health;

        public Health(float health)
        {
            _health = health;
        }

        public void Damage(float damage)
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

        public void Heal(float heal)
        {
            if (heal < 0)
                return;

            _health += heal;
            Debug.Log($"Heal {heal}");
            ChangedHealth?.Invoke(_health);
        }
    }
}