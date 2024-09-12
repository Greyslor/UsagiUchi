using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuPanel : MonoBehaviour, IPointerDownHandler
{
    public GameObject panel; // Asigna el Panel en el inspector
    private bool isMenuVisible = false; // Para controlar la visibilidad del men�

    void Start()
    {
        panel.SetActive(false); // Ocultar el men� al inicio
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        panel.SetActive(isMenuVisible); // Alternar la visibilidad del men�
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Verifica si el clic no est� dentro del panel
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            ToggleMenu(); // Ocultar el men� si se hace clic fuera del panel
        }
    }
}
