using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CambiarNombre : MonoBehaviour
{
    public InputField inputNuevoNombre; // Referencia al InputField
    public Button botonOk; // Referencia al botón OK
    public Button botonCancel; // Referencia al botón Cancel
    public Text mensajeError; // Referencia al Text que muestra mensajes de error o éxito

    void Start()
    {
        // Agrega listeners a los botones
        botonOk.onClick.AddListener(CambiarNombreJugador);
        botonCancel.onClick.AddListener(CancelarCambio);
    }

    void CambiarNombreJugador()
    {
        string nuevoNombre = inputNuevoNombre.text; // Obtiene el texto del InputField

        // Valida que el nombre sólo contenga letras
        if (Regex.IsMatch(nuevoNombre, "^[a-zA-Z]+$"))
        {
            PlayerPrefs.SetString("NombreJugador", nuevoNombre); // Guarda el nuevo nombre
            mensajeError.text = "Nombre cambiado con éxito!"; // Muestra un mensaje de éxito
        }
        else
        {
            mensajeError.text = "El nombre sólo debe contener letras."; // Muestra un mensaje de error
        }
    }

    void CancelarCambio()
    {
        inputNuevoNombre.text = ""; // Limpia el campo si se cancela el cambio
    }
}
