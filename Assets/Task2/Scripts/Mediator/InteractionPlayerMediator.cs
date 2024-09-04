using UnityEngine;

namespace Task2
{
    public class InteractionPlayerMediator
    {
        private Player _player;
        private InteractionPanel _panel;

        public InteractionPlayerMediator(Player player, InteractionPanel panel)
        {
            _player = player;
            _panel = panel;
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _panel.Healed += OnHealed;
            _panel.Damaged += OnDamaged;
            _panel.RaisedLevel += OnRaisedLevel;
        }

        private void Unsubscribe()
        {
            _panel.Healed -= OnHealed;
            _panel.Damaged -= OnDamaged;
            _panel.RaisedLevel -= OnRaisedLevel;
        }

        private void OnHealed(float heal)
        {
            Debug.Log($"OnHealed {heal}");
            _player.Heal(heal);
        }

        private void OnDamaged(float damage) 
        {
            Debug.Log($"OnDamaged {damage}");
            _player.Damage(damage);
        }

        private void OnRaisedLevel()
        {
            Debug.Log("OnRaisedLevel");
            _player.RaiseLevel();
        } 
    }
}