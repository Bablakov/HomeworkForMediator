using UnityEngine;

namespace Task2
{
    public class SpecificationPlayerMediator
    {
        private SpecificationPanel _panelSpecification;
        private Health _health;
        private Level _level;

        public SpecificationPlayerMediator(SpecificationPanel panelSpecification, Health health, Level level)
        {
            _panelSpecification = panelSpecification;
            _health = health;
            _level = level;
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

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
        {
            Debug.Log("OnChangedHealth");
            _panelSpecification.SetHealth(health);
        }

        private void OnChangedLevel(int level)
        {
            Debug.Log("OnChangedLevel");
            _panelSpecification.SetLevel(level);
        }
    }
}