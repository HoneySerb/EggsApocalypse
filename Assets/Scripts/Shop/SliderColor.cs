using UnityEngine.UI;
using UnityEngine;

public class SliderColor : MonoBehaviour
{
    [SerializeField] private ColorShade _colorShade;
    [SerializeField] private FloatEvent _colorChangeFloatEvent;
    [SerializeField] private ColorEvent _colorChangeEvent;

    private Slider _slider;


    public void OnChangeValue()
    {
        _colorChangeFloatEvent.Invoke(_slider.value);
        _colorChangeEvent.Invoke(_slider.value, _colorShade);
    }

    private void Awake() => _slider = GetComponent<Slider>();

    private void Start()
    {
        string colorValue = string.Empty;
        switch (_colorShade)
        {
            case ColorShade.Red: colorValue = "RedValue"; break;
            case ColorShade.Green: colorValue = "GreenValue"; break;
            case ColorShade.Blue: colorValue = "BlueValue"; break;
        }

        if (!PlayerPrefs.HasKey(colorValue)) { PlayerPrefs.SetFloat(colorValue, 255f); }

        _slider.value = PlayerPrefs.GetFloat(colorValue);
    }
}
