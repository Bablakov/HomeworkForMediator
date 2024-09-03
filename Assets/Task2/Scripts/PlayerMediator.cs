using UnityEngine;

namespace Task2
{
    public class PlayerMediator
    {
        private Player _player;
        private Panel _panel;

        public PlayerMediator(Player player, Panel panel)
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

        private void OnHealed(int heal)
        {
            Debug.Log($"OnHealed {heal}");
            _player.Heal(heal);
        }

        private void OnDamaged(int damage) 
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