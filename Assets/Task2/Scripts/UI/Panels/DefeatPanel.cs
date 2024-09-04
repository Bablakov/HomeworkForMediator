using System;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Task2.UI.Panels
{
    public class DefeatPanel : BasePanel
    {
        public event Action Restarted;

        [SerializeField] private Button _buttonRestart;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        private void Subscribe() 
            => _buttonRestart.onClick.AddListener(OnRestartClick);

        private void Unsubscribe() 
            => _buttonRestart.onClick.RemoveListener(OnRestartClick);

        private void OnRestartClick()
            => Restarted?.Invoke();
    }
}