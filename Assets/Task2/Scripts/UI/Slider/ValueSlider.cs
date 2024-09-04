using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task2.UI.SLider
{
    public class ValueSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textValue;

        private const string OutputFormat = "0.00";

        public float Value { get; private set; }
     
        public void Initialize(float minValue, float maxValue)
        {
            _slider.minValue = minValue;
            _slider.maxValue = maxValue;
            _slider.interactable = true;
        }

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        private void Subscribe()
            => _slider.onValueChanged.AddListener(OnValueChanged);

        private void Unsubscribe()
            => _slider.onValueChanged.RemoveListener(OnValueChanged);

        private void OnValueChanged(float newValue)
        {
            _textValue.text = newValue.ToString(OutputFormat);
            Value = newValue;
        }
    }
}