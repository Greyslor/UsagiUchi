using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public ConfirmationPanelManager confirmationPanelManager; // Referencia al panel de confirmaci�n

    private void Start()
    {
        // Asigna la referencia al ConfirmationPanelManager
        confirmationPanelManager = FindFirstObjectByType<ConfirmationPanelManager>(); // Usando el nuevo m�todo

        // Deshabilitar el bot�n Resume si no hay partida guardada
        bool hayPartidaGuardada = PlayerPrefs.HasKey("NombreJugador");
        GameObject botonResume = GameObject.Find("BotonResume");
        botonResume.GetComponent<UnityEngine.UI.Button>().interactable = hayPartidaGuardada;
    }

    public void ContinuarJuego()
    {
        SceneManager.LoadScene("Garden"); // Cambia esto al nombre real de tu escena de juego
    }

    public void CrearNuevoUsuario()
    {
        // Abre una ventana de confirmaci�n si ya hay un usuario
        if (PlayerPrefs.HasKey("NombreJugador"))
        {
            // Muestra el panel de confirmaci�n
            confirmationPanelManager.MostrarPanel();
        }
        else
        {
            SceneManager.LoadScene("CrearUsuario"); // Cambia esto al nombre de tu escena de creaci�n de usuario
        }
    }

    public void AbrirOpciones()
    {
        SceneManager.LoadScene("Opciones"); // Cambia esto al nombre de tu escena de opciones
    }
}
