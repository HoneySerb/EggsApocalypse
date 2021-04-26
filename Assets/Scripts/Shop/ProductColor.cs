using UnityEngine.UI;
using UnityEngine;

public class ProductColor : MonoBehaviour
{
    private Image _image;


    public void OnChangeColor(float value, ColorShade shade)
    {
        Color32 newColor = _image.color;
        switch (shade)
        {
            case ColorShade.Red: newColor.r = System.Convert.ToByte(value); break;
            case ColorShade.Green: newColor.g = System.Convert.ToByte(value); break;
            case ColorShade.Blue: newColor.b = System.Convert.ToByte(value); break;
        }

        SetColor(in newColor);
    }

    private void Awake() => _image = GetComponent<Image>();

    private void Start()
    {
        byte r = System.Convert.ToByte(PlayerPrefs.GetFloat("RedValue"));
        byte g = System.Convert.ToByte(PlayerPrefs.GetFloat("GreenValue"));
        byte b = System.Convert.ToByte(PlayerPrefs.GetFloat("BlueValue"));
        SetColor(new Color32(r, g, b, 255));
    }

    private void SetColor(in Color32 color) => _image.color = color;
}
