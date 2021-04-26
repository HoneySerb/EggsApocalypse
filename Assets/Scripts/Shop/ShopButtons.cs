using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] private Slider _sliderRed, _sliderGreen, _sliderBlue;
    [SerializeField] private Price _price;

    [SerializeField] private UnityEvent _buyEvent;


    public void Menu() => SceneManager.LoadScene("Menu");

    public void Buy()
    {
        float price = _price.TotalPrice;
        float balance = PlayerPrefs.GetFloat("Balance");
        if (balance > price)
        {
            PlayerPrefs.SetFloat("Balance", balance - price);

            _buyEvent.Invoke();

            SaveColor();
        }
    }

    private void SaveColor()
    {
        PlayerPrefs.SetFloat("RedValue", _sliderRed.value);
        PlayerPrefs.SetFloat("GreenValue", _sliderGreen.value);
        PlayerPrefs.SetFloat("BlueValue", _sliderBlue.value);
    }
}
