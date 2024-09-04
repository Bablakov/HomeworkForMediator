using System;
using Task2.Config;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task2
{
    public class InteractionPanel : MonoBehaviour
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
        {
            _playerConfig = playerConfig;
        }

        public void Initialize(PlayerConfig playerConfig)
        {
            _sliderHeal.Initialize(playerConfig.MinHeal, playerConfig.MaxHeal);
            _sliderDamage.Initialize(playerConfig.MinDamage, playerConfig.MaxDamage);
        }

        public void Subscribe()
        {
            _heal.onClick.AddListener(OnHealClick);
            _damage.onClick.AddListener(OnDamageClick);
            _raiceLevel.onClick.AddListener(OnRaiseLevelClick);
        }

        public void Unsubscribe()
        {
            _heal.onClick.RemoveListener(OnHealClick);
            _damage.onClick.RemoveListener(OnDamageClick);
            _raiceLevel.onClick.RemoveListener(OnRaiseLevelClick);
        }

        public void OnHealClick()
        {
            Debug.Log("OnHealClick");
            Healed?.Invoke(_sliderHeal.Value);
        }

        public void OnDamageClick()
        {
            Debug.Log("OnDamageClick");
            Damaged?.Invoke(_sliderDamage.Value);
        }

        public void OnRaiseLevelClick()
        {
            Debug.Log("OnRaiseLevelClick");
            RaisedLevel?.Invoke();
        }
    }
}