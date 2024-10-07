using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class CrearUsuario : MonoBehaviour
{
    public InputField nombreInput;
    public InputField edadInput;
    public Button confirmarButton;
    public Text mensajeError;

    void Start()
    {
        // Vincula el botón con la función de creación de partida
        confirmarButton.onClick.AddListener(CrearNuevaPartida);
    }

    public void CrearNuevaPartida()
    {
        string nombre = nombreInput.text;
        string edad = edadInput.text;

        // Verifica si los campos están vacíos
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(edad))
        {
            mensajeError.text = "Debes completar ambos campos.";
            return;
        }

        // Valida que el nombre solo contenga letras y que la edad sea mayor o igual a 3
        int edadJugador = 0;  // Declaramos la variable fuera de TryParse

        if (Regex.IsMatch(nombre, "^[a-zA-Z]+$") && int.TryParse(edad, out edadJugador) && edadJugador >= 3)
        {
            PlayerPrefs.SetString("NombreJugador", nombre);
            PlayerPrefs.SetInt("EdadJugador", edadJugador);
            PlayerPrefs.SetInt("PartidaGuardada", 1); // Marca que hay una partida guardada
            AsignarRegaloInicial();
            SceneManager.LoadScene("Garden"); // Cargar la escena del juego
        }
        else
        {
            // Mostrar mensajes de error específicos
            if (!Regex.IsMatch(nombre, "^[a-zA-Z]+$"))
            {
                mensajeError.text = "El nombre solo debe contener letras.";
            }
            else if (!int.TryParse(edad, out edadJugador) || edadJugador < 3)
            {
                mensajeError.text = "La edad debe ser mayor o igual a 3.";
            }
        }
    }

    private void AsignarRegaloInicial()
    {
        // Regalo inicial aleatorio
        string[] comida = { "Zanahoria", "Lechuga", "Heno" };
        string[] juguete = { "Pelota", "Cuerda", "Rueda" };

        PlayerPrefs.SetString("ComidaInicial", comida[Random.Range(0, comida.Length)]);
        PlayerPrefs.SetString("JugueteInicial", juguete[Random.Range(0, juguete.Length)]);
    }
}
