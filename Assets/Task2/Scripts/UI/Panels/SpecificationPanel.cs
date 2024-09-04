using TMPro;
using UnityEngine;

namespace Task2
{
    public class SpecificationPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHealth;
        [SerializeField] private TextMeshProUGUI _textLevel;

        public void SetHealth(float health)
        {
            Debug.Log($"SetHealth {health}");
            _textHealth.text = "Health " + health;
        }

        public void SetLevel(int level)
        {
            Debug.Log($"SetLevel {level}");
            _textLevel.text = "Level " + level;
        }
    }
}