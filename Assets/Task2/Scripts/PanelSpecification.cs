using TMPro;
using UnityEngine;

namespace Task2
{
    public class PanelSpecification : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHealth;
        [SerializeField] private TextMeshProUGUI _textLevel;

        public void SetHealth(int health)
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