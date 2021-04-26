using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private FloatEvent _moveEvent;
    [SerializeField] private BoolEvent _jumpEvent;


    public void OnPointerEnter(PointerEventData eventData)
    {
        switch(gameObject.name)
        {
            case "BLeft": _moveEvent.Invoke(-1f); break;
            case "BRight": _moveEvent.Invoke(1f); break;
            case "BJump": _jumpEvent.Invoke(true); break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.name == "BJump")
        {
            _jumpEvent.Invoke(false);
        }
        else
        {
            _moveEvent.Invoke(0f);
        }
    }
}
