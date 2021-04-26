using UnityEngine;

public class UIEnableAnim : MonoBehaviour   //Изменить название
{
    private Vector3 _startScale = new Vector3(0f, 0f, 1f);
    private Vector3 _targetScale;
    private Vector3 _finalScale;

    private bool _isRising = true;


    private void Awake()
    {
        _finalScale = new Vector3(transform.localScale.x, transform.localScale.y, 1f);
        _targetScale = new Vector3(_finalScale.x * 1.15f, _finalScale.y * 1.15f, 1f);
    }

    private void OnEnable()
    {
        transform.localScale = _startScale;
        _isRising = true;
    }

    private void Update()
    {
        if (_isRising)
        {
            if (transform.localScale == _targetScale)
            {
                _isRising = false;
            }
            else
            {
                ChangeScale(in _targetScale);
            }
        }
        else
        {
            ChangeScale(in _finalScale);
        }
    }

    private void ChangeScale(in Vector3 targetScale)
    {
        Vector3 currentScale = transform.localScale;

        float xScale = Mathf.MoveTowards(currentScale.x, targetScale.x, Time.deltaTime * 2);
        float yScale = Mathf.MoveTowards(currentScale.y, targetScale.y, Time.deltaTime * 2);

        Vector3 newScale = new Vector3(xScale, yScale, 1f);

        transform.localScale = newScale;
    }
}
