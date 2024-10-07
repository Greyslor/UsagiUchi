using UnityEngine;
using UnityEngine.UI;

public class AjustarVolumen : MonoBehaviour
{
    public Slider sliderVolumen; // Referencia al Slider
    public Text textoVolumen; // Referencia al Text que muestra el volumen

    void Start()
    {
        // Carga el volumen guardado o establece 0.5 como predeterminado
        float volumenGuardado = PlayerPrefs.GetFloat("Volumen", 0.5f);
        sliderVolumen.value = volumenGuardado; // Establece el valor del slider

        // Establece el volumen del AudioListener al volumen guardado
        AudioListener.volume = volumenGuardado;

        // Actualiza el texto del volumen
        ActualizarTextoVolumen(volumenGuardado);

        // Agrega un listener al Slider para que llame a CambiarVolumen cuando se cambie el valor
        sliderVolumen.onValueChanged.AddListener(delegate {
            CambiarVolumen(sliderVolumen.value);
        });
    }

    void CambiarVolumen(float volumen)
    {
        // Cambia el volumen del AudioListener
        AudioListener.volume = volumen;

        // Guarda el volumen en PlayerPrefs
        PlayerPrefs.SetFloat("Volumen", volumen);

        // Actualiza el texto del volumen
        ActualizarTextoVolumen(volumen);
    }

    void ActualizarTextoVolumen(float volumen)
    {
        // Actualiza el texto para mostrar el volumen en porcentaje
        textoVolumen.text = $"Volumen: {(volumen * 100).ToString("0")}%";
    }
}
