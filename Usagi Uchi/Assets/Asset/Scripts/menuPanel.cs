using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuPanel : MonoBehaviour, IPointerDownHandler
{
    public GameObject panel; // Asigna el Panel en el inspector
    private bool isMenuVisible = false; // Para controlar la visibilidad del menú

    void Start()
    {
        panel.SetActive(false); // Ocultar el menú al inicio
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        panel.SetActive(isMenuVisible); // Alternar la visibilidad del menú
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Verifica si el clic no está dentro del panel
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            ToggleMenu(); // Ocultar el menú si se hace clic fuera del panel
        }
    }
}
