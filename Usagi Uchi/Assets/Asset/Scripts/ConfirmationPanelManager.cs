using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanelManager : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button botonAceptar;
    public Button botonCancelar;

    private void Start()
    {
        // Desactivar el panel al inicio
        confirmationPanel.SetActive(false);

        // Asignar m�todos a los botones
        botonAceptar.onClick.AddListener(AceptarCreacion);
        botonCancelar.onClick.AddListener(CancelarCreacion);
    }

    public void MostrarPanel()
    {
        confirmationPanel.SetActive(true); // Mostrar el panel de confirmaci�n
    }

    private void AceptarCreacion()
    {
        // L�gica para sobrescribir la partida existente
        PlayerPrefs.DeleteKey("NombreJugador"); // Eliminar la partida anterior
        PlayerPrefs.DeleteKey("EdadJugador");
        // L�gica para crear un nuevo usuario
        // (llama a la funci�n de creaci�n de usuario o carga la escena de creaci�n de usuario)
        // Por ejemplo:
        UnityEngine.SceneManagement.SceneManager.LoadScene("CrearUsuario"); // Cambia al nombre de la escena de creaci�n
    }

    private void CancelarCreacion()
    {
        confirmationPanel.SetActive(false); // Ocultar el panel de confirmaci�n
    }
}
