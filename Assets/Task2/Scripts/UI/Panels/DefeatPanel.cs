using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task2
{
    public class DefeatPanel : MonoBehaviour
    {
        public event Action Restarted;

        [SerializeField] private Button _buttonRestart;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void Subscribe()
        {
            _buttonRestart.onClick.AddListener(OnRestartClick);
        }

        private void Unsubscribe()
        {
            _buttonRestart.onClick.RemoveListener(OnRestartClick);
        }

        private void OnRestartClick()
            => Restarted?.Invoke();
    }
}