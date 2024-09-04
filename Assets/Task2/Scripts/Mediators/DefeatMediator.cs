using UnityEngine.SceneManagement;
using Task2.PlayersComponent;
using Task2.UI.Panels;
using System;

namespace Task2.Mediators
{
    public class DefeatMediator : IDisposable
    {
        private Player _player;
        private DefeatPanel _panelRestart;

        public DefeatMediator(Player player, DefeatPanel panelRestart)
        {
            _player = player;
            _panelRestart = panelRestart;

            _panelRestart.Hide();

            Subscribe();
        }

        public void Dispose() => Unsubscribe();

        private void Subscribe()
        {
            _player.Defeat += OnDefeat;
            _panelRestart.Restarted += OnRestarted;
        }

        private void Unsubscribe()
        {
            _player.Defeat -= OnDefeat;
            _panelRestart.Restarted -= OnRestarted;
        }

        private void OnDefeat() => _panelRestart.Show();

        private void OnRestarted()
        {
            _panelRestart.Hide();
            _player.Reset();
        }
    }
}