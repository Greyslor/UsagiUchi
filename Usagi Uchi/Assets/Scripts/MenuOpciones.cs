using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public GameObject menuPanel;
    public Slider volumenSlider;
    public Toggle pantallaCompletaToggle;

    void Start()
    {
        volumenSlider.onValueChanged.AddListener(CambiarVolumen);
        pantallaCompletaToggle.onValueChanged.AddListener(CambiarPantallaCompleta);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
    }

    public void CambiarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void MostrarMenu()
    {
        menuPanel.SetActive(true);
    }

    public void OcultarMenu()
    {
        menuPanel.SetActive(false);
    }
}

