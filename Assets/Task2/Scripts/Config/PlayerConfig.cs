using System;
using UnityEngine;

namespace Task2.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 100)] public float Health { get; private set; }
        [field: SerializeField, Range(0, 10)] public float MinDamage { get; private set; }
        [field: SerializeField, Range(0, 10)] public float MaxDamage { get; private set; }
        [field: SerializeField, Range(0, 10)] public float MinHeal { get; private set; }
        [field: SerializeField, Range(0, 10)] public float MaxHeal { get; private set; }
        
        [SerializeField, Range(0, 0.1f)] private float _differenceValues = 0.01f;

        private void OnValidate()
        {
            CheckDamageHeal();
            CheckHealValue();
        }

        private void CheckDamageHeal()
        {
            if (MinDamage >= MaxDamage - _differenceValues)
                MinDamage = MaxDamage - _differenceValues;

            if (MinDamage >= MaxDamage)
                MaxDamage = MinDamage + _differenceValues;
        }

        private void CheckHealValue()
        {
            if (MinHeal >= MaxHeal - _differenceValues)
                MinHeal = MaxHeal - _differenceValues;

            if (MinHeal >= MaxHeal)
                MaxHeal = MinHeal + _differenceValues;
        }
    }
}