using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CambiarNombre : MonoBehaviour
{
    public InputField inputNuevoNombre; // Referencia al InputField
    public Button botonOk; // Referencia al bot�n OK
    public Button botonCancel; // Referencia al bot�n Cancel
    public Text mensajeError; // Referencia al Text que muestra mensajes de error o �xito

    void Start()
    {
        // Agrega listeners a los botones
        botonOk.onClick.AddListener(CambiarNombreJugador);
        botonCancel.onClick.AddListener(CancelarCambio);
    }

    void CambiarNombreJugador()
    {
        string nuevoNombre = inputNuevoNombre.text; // Obtiene el texto del InputField

        // Valida que el nombre s�lo contenga letras
        if (Regex.IsMatch(nuevoNombre, "^[a-zA-Z]+$"))
        {
            PlayerPrefs.SetString("NombreJugador", nuevoNombre); // Guarda el nuevo nombre
            mensajeError.text = "Nombre cambiado con �xito!"; // Muestra un mensaje de �xito
        }
        else
        {
            mensajeError.text = "El nombre s�lo debe contener letras."; // Muestra un mensaje de error
        }
    }

    void CancelarCambio()
    {
        inputNuevoNombre.text = ""; // Limpia el campo si se cancela el cambio
    }
}
