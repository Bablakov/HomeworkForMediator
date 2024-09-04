using UnityEngine;
using Task2.UI.Panels;
using Task2.PlayersComponent;
using System;

namespace Task2.Mediators
{
    public class SpecificationPlayerMediator : IDisposable
    {
        private SpecificationPanel _panelSpecification;
        private Health _health;
        private Level _level;

        public SpecificationPlayerMediator(SpecificationPanel panelSpecification, Health health, Level level)
        {
            _panelSpecification = panelSpecification;
            _health = health;
            _level = level;

            OnChangedHealth(_health.CurrentHealth);
            OnChangedLevel(_level.CurrentLevel);

            Subscribe();
        }

        public void Dispose() => Unsubscribe();

        private void Subscribe()
        {
            _health.ChangedHealth += OnChangedHealth;
            _level.ChangedLevel += OnChangedLevel;
        }

        private void Unsubscribe()
        {
            _health.ChangedHealth -= OnChangedHealth;
            _level.ChangedLevel -= OnChangedLevel;
        }

        private void OnChangedHealth(float health) 
            => _panelSpecification.SetHealth(health);

        private void OnChangedLevel(int level)
            => _panelSpecification.SetLevel(level);
    }
}