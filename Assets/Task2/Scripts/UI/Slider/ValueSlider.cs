using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textValue;

    public float Value { get; private set; }
     
    public void Initialize(float minValue, float maxValue)
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;
    }

    private void OnEnable() => Subscribe();

    private void OnDisable() => Unsubscribe();

    private void Subscribe()
        => _slider.onValueChanged.AddListener(OnValueChanged);

    private void Unsubscribe()
        => _slider.onValueChanged.RemoveListener(OnValueChanged);

    private void OnValueChanged(float newValue)
    {
        _textValue.text = newValue.ToString();
        Value = newValue;
    }
}