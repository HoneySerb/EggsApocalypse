using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ControlButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _alphaHide;
    [SerializeField] private List<GameObject> _buttonsList;    //Hide
    [SerializeField] private List<GameObject> _imagesList;     //Show
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowAndHide(true);
        SetColorAlpha(_alphaHide);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowAndHide(false);
        SetColorAlpha(255f);
    }

    private void ShowAndHide(bool isShow)
    {
        foreach (GameObject obj in _imagesList) { obj.SetActive(isShow); }  

        foreach (GameObject obj in _buttonsList) { obj.SetActive(!isShow); }
    }

    private void SetColorAlpha(float alpha)
    {
        GetComponent<Image>().color = new Color(255f, 255f, 255f, alpha);
        GetComponentInChildren<Text>().color = new Color(0, 255, 0, alpha);
    }
}
