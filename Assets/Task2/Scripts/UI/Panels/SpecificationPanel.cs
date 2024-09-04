using TMPro;
using UnityEngine;

namespace Task2.UI.Panels
{
    public class SpecificationPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI _textHealth;
        [SerializeField] private TextMeshProUGUI _textLevel;

        private const string OutputFormat = "0.00";

        public void SetHealth(float health)
            => _textHealth.text = "Health " + health.ToString(OutputFormat);

        public void SetLevel(int level)
            => _textLevel.text = "Level " + level;
    }
}