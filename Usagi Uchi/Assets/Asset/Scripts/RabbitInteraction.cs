using UnityEngine;
using UnityEngine.UI;

public class RabbitInteraction : MonoBehaviour
{
    private GameObject interactionPanel;
    private Button giftsButton;
    private Button memoriesButton;
    private Button playButton;
    private Button closeButton; // Agregamos el bot�n de cerrar

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas"); // Aseg�rate de que el nombre del Canvas sea correcto
        if (canvas == null)
        {
            Debug.LogError("El Canvas no se encontr�. Verifica el nombre y la jerarqu�a.");
            return;
        }

        interactionPanel = canvas.transform.Find("InteractionPanel").gameObject;
        if (interactionPanel == null)
        {
            Debug.LogError("El panel de interacci�n no se encontr�. Verifica el nombre y la jerarqu�a.");
            return;
        }

        interactionPanel.SetActive(false); // Desactiva el panel al inicio

        // Encuentra los botones dentro del panel
        giftsButton = interactionPanel.transform.Find("Regalos").GetComponent<Button>();
        memoriesButton = interactionPanel.transform.Find("Recuerdos").GetComponent<Button>();
        playButton = interactionPanel.transform.Find("Jugar").GetComponent<Button>();
        closeButton = interactionPanel.transform.Find("Close").GetComponent<Button>(); // Encuentra el bot�n de cerrar

        // Verifica que los botones no sean nulos
        if (giftsButton == null || memoriesButton == null || playButton == null || closeButton == null)
        {
            Debug.LogError("Uno o m�s botones no se encontraron. Verifica los nombres.");
            return;
        }

        // Asignar m�todos a los botones
        giftsButton.onClick.AddListener(ShowGifts);
        memoriesButton.onClick.AddListener(ShowMemories);
        playButton.onClick.AddListener(StartMinigame);
        closeButton.onClick.AddListener(CloseInteractionPanel); // Asigna el m�todo para cerrar el panel
    }

    void OnMouseDown()
    {
        // Muestra el panel de interacci�n al tocar el conejo
        interactionPanel.SetActive(true);
    }

    void ShowGifts()
    {
        Debug.Log("Mostrando regalos");
    }

    void ShowMemories()
    {
        Debug.Log("Mostrando recuerdos");
    }

    void StartMinigame()
    {
        Debug.Log("Iniciando minijuego");
    }

    void CloseInteractionPanel()
    {
        interactionPanel.SetActive(false); // Cierra el panel de interacci�n
    }
}
