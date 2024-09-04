using UnityEngine;
using Task2.UI.Panels;
using Task2.PlayersComponent;
using System;

namespace Task2.Mediators
{
    public class InteractionPlayerMediator : IDisposable
    {
        private Player _player;
        private InteractionPanel _panel;

        public InteractionPlayerMediator(Player player, InteractionPanel panel)
        {
            _player = player;
            _panel = panel;
            Subscribe();
        }

        public void Dispose() => Unsubscribe();

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
            => _player.Heal(heal);

        private void OnDamaged(float damage) 
            => _player.Damage(damage);

        private void OnRaisedLevel()
            => _player.RaiseLevel();
    }
}