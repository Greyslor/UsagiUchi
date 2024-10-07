using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public ConfirmationPanelManager confirmationPanelManager; // Referencia al panel de confirmación

    private void Start()
    {
        // Asigna la referencia al ConfirmationPanelManager
        confirmationPanelManager = FindFirstObjectByType<ConfirmationPanelManager>(); // Usando el nuevo método

        // Deshabilitar el botón Resume si no hay partida guardada
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
        // Abre una ventana de confirmación si ya hay un usuario
        if (PlayerPrefs.HasKey("NombreJugador"))
        {
            // Muestra el panel de confirmación
            confirmationPanelManager.MostrarPanel();
        }
        else
        {
            SceneManager.LoadScene("CrearUsuario"); // Cambia esto al nombre de tu escena de creación de usuario
        }
    }

    public void AbrirOpciones()
    {
        SceneManager.LoadScene("Opciones"); // Cambia esto al nombre de tu escena de opciones
    }
}
