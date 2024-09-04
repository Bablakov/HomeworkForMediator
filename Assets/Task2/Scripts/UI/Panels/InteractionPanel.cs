using System;
using Task2.Config;
using Task2.UI.SLider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task2.UI.Panels
{
    public class InteractionPanel : BasePanel, IInitializable
    {
        public event Action<float> Healed;
        public event Action<float> Damaged;
        public event Action RaisedLevel;

        [SerializeField] private Button _heal;
        [SerializeField] private Button _damage;
        [SerializeField] private Button _raiceLevel;

        [SerializeField] private ValueSlider _sliderHeal;
        [SerializeField] private ValueSlider _sliderDamage;

        private PlayerConfig _playerConfig;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        [Inject]
        public void Construct(PlayerConfig playerConfig) 
            => _playerConfig = playerConfig;

        public void Initialize()
        {
            _sliderHeal.Initialize(_playerConfig.MinHeal, _playerConfig.MaxHeal);
            _sliderDamage.Initialize(_playerConfig.MinDamage, _playerConfig.MaxDamage);
        }

        private void Subscribe()
        {
            _heal.onClick.AddListener(OnHealClick);
            _damage.onClick.AddListener(OnDamageClick);
            _raiceLevel.onClick.AddListener(OnRaiseLevelClick);
        }

        private void Unsubscribe()
        {
            _heal.onClick.RemoveListener(OnHealClick);
            _damage.onClick.RemoveListener(OnDamageClick);
            _raiceLevel.onClick.RemoveListener(OnRaiseLevelClick);
        }

        private void OnHealClick()
            => Healed?.Invoke(_sliderHeal.Value);

        private void OnDamageClick() 
            => Damaged?.Invoke(_sliderDamage.Value);

        private void OnRaiseLevelClick() 
            => RaisedLevel?.Invoke();
    }
}