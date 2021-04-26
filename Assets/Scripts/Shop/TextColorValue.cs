using UnityEngine.UI;
using UnityEngine;

public class TextColorValue : MonoBehaviour
{
    [SerializeField] private ColorShade _colorShade;

    private Text _text;


    public void OnNewColor(float value) => _text.text = value.ToString();

    private void Awake() => _text = GetComponent<Text>();

    private void Start()
    {
        string color = string.Empty;
        switch (_colorShade)
        {
            case ColorShade.Red: color = "RedValue"; break;
            case ColorShade.Green: color = "GreenValue"; break;
            case ColorShade.Blue: color = "BlueValue"; break;
        }

        OnNewColor(PlayerPrefs.GetFloat(color));
    }
}