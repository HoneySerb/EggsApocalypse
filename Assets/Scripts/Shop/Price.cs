using UnityEngine.UI;
using UnityEngine;

public class Price : MonoBehaviour
{
    public float TotalPrice { get; private set; }
    private float _priceRed = 0f;
    private float _priceGreen = 0f;
    private float _priceBlue = 0f;

    private Text _text;


    public void OnChangeColor(float value, ColorShade shade)
    {
        switch (shade)
        {
            case ColorShade.Red: _priceRed = GetColorPrice("RedValue", value); break;
            case ColorShade.Green: _priceGreen = GetColorPrice("GreenValue", value); break;
            case ColorShade.Blue: _priceBlue = GetColorPrice("BlueValue", value); break;
        }

        SetTotalPrice();
    }

    private void Awake() => _text = GetComponent<Text>();

    private void Start() => SetTotalPrice();

    private float GetColorPrice(string type, float color)
    {
        float actColor = PlayerPrefs.GetFloat(type);

        float price = actColor > color ? Mathf.Abs(actColor - color) : Mathf.Abs(color - actColor);

        return price / 10;
    }

    private void SetTotalPrice()
    {
        TotalPrice = _priceRed + _priceGreen + _priceBlue;

        _text.text = TotalPrice == 0f ? "0" : string.Format("-{0:0.0}", TotalPrice);
    }
}
