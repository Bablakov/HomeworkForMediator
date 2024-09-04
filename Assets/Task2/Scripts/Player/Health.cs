using System;
using Task2.Config;
using UnityEngine;
using Zenject;

namespace Task2.PlayersComponent
{
    public class Health
    {
        public event Action HealthOver;
        public event Action<float> ChangedHealth;

        private float _startHealth;

        public Health(PlayerConfig playerConfig) =>
            CurrentHealth = _startHealth = playerConfig.Health;

        public float CurrentHealth { get; private set; }
        
        public void Damage(float damage)
        {
            if (damage < 0)
                return;

            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                HealthOver?.Invoke();
            }

            ChangedHealth?.Invoke(CurrentHealth);
        }

        public void Heal(float heal)
        {
            if (heal < 0)
                return;

            CurrentHealth += heal;
            ChangedHealth?.Invoke(CurrentHealth);
        }

        public void Reset()
        {
            CurrentHealth = _startHealth;
            ChangedHealth?.Invoke(CurrentHealth);
        }
    }
}