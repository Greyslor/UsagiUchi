using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public Dropdown dropdownIdioma; // Referencia al Dropdown
    public Text textoPrueba; // Referencia al Text que mostrará el mensaje

    void Start()
    {
        // Carga el idioma guardado o establece Español como predeterminado
        int idiomaGuardado = PlayerPrefs.GetInt("Idioma", 0); // 0 = Español, 1 = Inglés
        dropdownIdioma.value = idiomaGuardado;
        CambiarIdioma(idiomaGuardado); // Cambia el idioma inicial

        // Agrega un listener al Dropdown para que llame a CambiarIdioma cuando se cambie la selección
        dropdownIdioma.onValueChanged.AddListener(delegate {
            CambiarIdioma(dropdownIdioma.value);
        });
    }

    void CambiarIdioma(int idiomaIndex)
    {
        // Guarda el idioma seleccionado
        PlayerPrefs.SetInt("Idioma", idiomaIndex);

        // Cambia el texto dependiendo del idioma seleccionado
        if (idiomaIndex == 0)
        {
            textoPrueba.text = "¡Hola, bienvenido a tu jardín!"; // Español
        }
        else if (idiomaIndex == 1)
        {
            textoPrueba.text = "¡Hi, welcome to the garden!"; // Inglés
        }
        // Aquí puedes agregar más textos en otros lugares según el idioma
    }
}
