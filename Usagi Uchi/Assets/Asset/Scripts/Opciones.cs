using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public Dropdown dropdownIdioma; // Referencia al Dropdown
    public Text textoPrueba; // Referencia al Text que mostrar� el mensaje

    void Start()
    {
        // Carga el idioma guardado o establece Espa�ol como predeterminado
        int idiomaGuardado = PlayerPrefs.GetInt("Idioma", 0); // 0 = Espa�ol, 1 = Ingl�s
        dropdownIdioma.value = idiomaGuardado;
        CambiarIdioma(idiomaGuardado); // Cambia el idioma inicial

        // Agrega un listener al Dropdown para que llame a CambiarIdioma cuando se cambie la selecci�n
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
            textoPrueba.text = "�Hola, bienvenido a tu jard�n!"; // Espa�ol
        }
        else if (idiomaIndex == 1)
        {
            textoPrueba.text = "�Hi, welcome to the garden!"; // Ingl�s
        }
        // Aqu� puedes agregar m�s textos en otros lugares seg�n el idioma
    }
}
