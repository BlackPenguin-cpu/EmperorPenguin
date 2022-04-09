using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ShopButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI UITextMeshPro;
    public void OnPointerDown(PointerEventData eventData)
    {
        UITextMeshPro.transform.localPosition -= new Vector3(0, 10);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UITextMeshPro.transform.localPosition -= new Vector3(0, -10);
    }
}
