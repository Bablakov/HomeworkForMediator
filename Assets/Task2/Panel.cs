using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task2
{
    public class Panel : MonoBehaviour
    {
        public event Action<int> Healed;
        public event Action<int> Damaged;
        public event Action RaisedLevel;

        [SerializeField] private Button _heal;
        [SerializeField] private Button _damage;
        [SerializeField] private Button _raiceLevel;

        [SerializeField, Range(0, 10)] private int _valueHeal;
        [SerializeField, Range(0, 10)] private int _valueDamage;

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
            Healed?.Invoke(_valueHeal);
        }

        public void OnDamageClick()
        {
            Debug.Log("OnDamageClick");
            Damaged?.Invoke(_valueDamage);
        }

        public void OnRaiseLevelClick()
        {
            Debug.Log("OnRaiseLevelClick");
            RaisedLevel?.Invoke();
        }
    }
}