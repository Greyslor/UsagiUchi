using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Button resumeButton;
    public Button newButton;
    public Button optionsButton;
    public GameObject confirmationPanel;

    void Start()
    {
        // Desactiva el botón "Resume" si no hay partida guardada
        if (!PlayerPrefs.HasKey("PartidaGuardada"))
        {
            resumeButton.interactable = false;
        }
    }

    public void ResumeGame()
    {
        // Carga el juego guardado
        SceneManager.LoadScene("Juego");
    }

    public void NewGame()
    {
        if (PlayerPrefs.HasKey("PartidaGuardada"))
        {
            confirmationPanel.SetActive(true); // Mostrar confirmación si hay una partida guardada
        }
        else
        {
            CrearNuevaPartida();
        }
    }

    public void ConfirmNewGame(bool confirmar)
    {
        if (confirmar)
        {
            CrearNuevaPartida(); // Proceder con la nueva partida si se confirma
        }
        else
        {
            confirmationPanel.SetActive(false); // Cerrar el panel de confirmación si se cancela
        }
    }

    public void OpenOptions()
    {
        // Abrir el panel de opciones
        SceneManager.LoadScene("Opciones");
    }

    private void CrearNuevaPartida()
    {
        // Restablecer los valores por defecto
        PlayerPrefs.DeleteAll(); // Borrar el progreso anterior si existe
        SceneManager.LoadScene("CrearUsuario"); // Llamar a la escena de creación de usuario
    }
}
