using UnityEngine.UI;
using UnityEngine;

public class Banner : MonoBehaviour
{
    [SerializeField] private float _startChildFilling;
    [SerializeField] private float _time, _childMultiplier;

    private Image _banner;
    private Image _childBanner;

    private bool _isReady = false;


    private void Awake()
    {
        _childBanner = GetComponentsInChildren<Image>()[1];
        _banner = GetComponent<Image>();
    }

    private void Start()
    {
        _banner.fillAmount = 0f;
        _childBanner.fillAmount = 0f;
    }

    private void Update()
    {
        if (_banner.fillAmount != 1f || _childBanner.fillAmount != 1f)
        {
            if (_banner.fillAmount >= _startChildFilling) { _isReady = true; }

            if (_isReady) { _childBanner.fillAmount = Mathf.MoveTowards(_childBanner.fillAmount, 1f, Time.deltaTime * _time * _childMultiplier); }

            _banner.fillAmount = Mathf.MoveTowards(_banner.fillAmount, 1f, Time.deltaTime * _time);
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
