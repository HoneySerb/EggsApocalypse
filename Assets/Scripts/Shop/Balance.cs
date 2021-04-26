using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Balance : MonoBehaviour
{
    private Text _text;


    public void OnNewBalance()
    {
        StartCoroutine(ChangeBalanceDynamicaly());
    }

    private void Awake() => _text = GetComponent<Text>();

    private void Start()
    {
        float balance = PlayerPrefs.GetFloat("Balance");
        _text.text = string.Format("{0:0.0}", balance);
    }

    private IEnumerator ChangeBalanceDynamicaly()
    {
        float textBalance = float.Parse(_text.text);
        while (textBalance != PlayerPrefs.GetFloat("Balance"))
        {
            textBalance = Mathf.MoveTowards(textBalance, PlayerPrefs.GetFloat("Balance"), 2f);

            _text.text = string.Format("{0:0.0}", textBalance);

            yield return null;
        }
    }
}
