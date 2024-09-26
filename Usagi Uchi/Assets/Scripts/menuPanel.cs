using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuPanel : MonoBehaviour, IPointerDownHandler
{
    public GameObject panel;
    private bool isMenuVisible = false;

    void Start()
    {
        panel.SetActive(false); 
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        panel.SetActive(isMenuVisible); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            ToggleMenu();
        }
    }
}
