using UnityEngine.SceneManagement;

namespace Task2
{
    public class DefeatMediator
    {
        private Health _health;
        private DefeatPanel _panelRestart;

        public DefeatMediator(Health health, DefeatPanel panelRestart)
        {
            _health = health;
            _panelRestart = panelRestart;

            _panelRestart.Hide();

            Subscribe();
        }

        private void Subscribe()
        {
            _health.HealthOver += OnHealthOver;
            _panelRestart.Restarted += OnRestarted;
        }

        private void Unsubscribe()
        {
            _health.HealthOver -= OnHealthOver;
            _panelRestart.Restarted -= OnRestarted;
        }

        private void OnHealthOver()
        {
            _panelRestart.Show();
        }
        
        private void OnRestarted()
        {
            SceneManager.LoadScene(0);
        }
    }
}