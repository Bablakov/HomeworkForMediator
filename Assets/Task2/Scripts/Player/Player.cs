using System;

namespace Task2
{
    public class Player : IDisposable
    {
        public event Action Defeat;

        private Health _health;
        private Level _level;

        public Player(Health health, Level level)
        {
            _health = health;
            _level = level;

            Subscribe();
        }

        public void Dispose() => Unsubscribe();

        private void Subscribe() => _health.HealthOver += OnHealthOver;

        private void Unsubscribe() => _health.HealthOver -= OnHealthOver;

        private void OnHealthOver() => Defeat?.Invoke();

        public void Damage(float damage) => _health.Damage(damage);

        public void Heal(float heal) => _health.Heal(heal);

        public void RaiseLevel() => _level.RaiseLevel();
    }
}