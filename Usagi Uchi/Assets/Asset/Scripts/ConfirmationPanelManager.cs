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

        // Asignar métodos a los botones
        botonAceptar.onClick.AddListener(AceptarCreacion);
        botonCancelar.onClick.AddListener(CancelarCreacion);
    }

    public void MostrarPanel()
    {
        confirmationPanel.SetActive(true); // Mostrar el panel de confirmación
    }

    private void AceptarCreacion()
    {
        // Lógica para sobrescribir la partida existente
        PlayerPrefs.DeleteKey("NombreJugador"); // Eliminar la partida anterior
        PlayerPrefs.DeleteKey("EdadJugador");
        // Lógica para crear un nuevo usuario
        // (llama a la función de creación de usuario o carga la escena de creación de usuario)
        // Por ejemplo:
        UnityEngine.SceneManagement.SceneManager.LoadScene("CrearUsuario"); // Cambia al nombre de la escena de creación
    }

    private void CancelarCreacion()
    {
        confirmationPanel.SetActive(false); // Ocultar el panel de confirmación
    }
}
