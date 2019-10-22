using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float scale = 1.05f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }
}
