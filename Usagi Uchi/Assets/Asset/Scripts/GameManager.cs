using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Asignar desde el Inspector
    public Canvas uiCanvas; // El canvas que contiene el texto de los huevos y mensajes
    public Text eggText; // El componente de texto donde se mostrar� el contador de huevos
    public Text messageText; // El componente de texto para mostrar mensajes de compra

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruyas este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evita que haya m�ltiples instancias
        }
    }

    public int totalEasterEggs = 0; // Contador de huevos de pascua

    // Este m�todo a�ade huevos de pascua al total
    public void AddEasterEgg(int amount)
    {
        totalEasterEggs += amount;
        Debug.Log("Huevos de Pascua totales: " + totalEasterEggs);
        UpdateEasterEggUI(); // Actualiza el texto del UI
    }

    // Actualiza el texto del UI con el n�mero actual de huevos
    private void UpdateEasterEggUI()
    {
        if (eggText != null)
        {
            eggText.text = " " + totalEasterEggs.ToString();
        }
        else
        {
            Debug.LogError("No se encontr� el componente de texto 'eggText'. Aseg�rate de asignarlo en el Inspector.");
        }
    }

    // M�todo para comprar un �tem
    public void BuyItem(string itemName)
    {
        int cost = 0;
        switch (itemName)
        {
            case "alfalfa":
                cost = 4;
                break;
            case "almohada":
                cost = 18;
                break;
            case "zanahoria":
                cost = 5;
                break;
            case "corral":
                cost = 24;
                break;
            default:
                Debug.LogError("�tem no reconocido: " + itemName);
                return;
        }

        if (totalEasterEggs >= cost)
        {
            totalEasterEggs -= cost;
            UpdateEasterEggUI(); // Actualiza el texto del UI
            ShowMessage("�Compraste " + itemName + "!");
        }
        else
        {
            ShowMessage("No tienes suficientes huevos de pascua para comprar " + itemName + ".");
        }
    }

    // M�todo para mostrar mensajes en la UI
    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
        else
        {
            Debug.LogError("No se encontr� el componente de texto 'messageText'. Aseg�rate de asignarlo en el Inspector.");
        }
    }

    // Opcional: Guarda el progreso de los huevos de pascua
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("EasterEggs", totalEasterEggs);
        PlayerPrefs.Save();
    }

    // Opcional: Carga el progreso de los huevos de pascua
    public void LoadProgress()
    {
        totalEasterEggs = PlayerPrefs.GetInt("EasterEggs", 0);
        Debug.Log("Progreso cargado. Huevos de Pascua: " + totalEasterEggs);
        UpdateEasterEggUI(); // Aseg�rate de actualizar el UI despu�s de cargar los huevos
    }

    private void Start()
    {
        LoadProgress(); // Cargar progreso al iniciar
    }

    private void OnApplicationQuit()
    {
        SaveProgress(); // Guardar progreso al salir de la aplicaci�n
    }

    // M�todo para asignar componentes cuando sea necesario
    public void AssignUIComponents(Canvas newCanvas)
    {
        if (newCanvas == null)
        {
            Debug.LogError("El nuevo Canvas es nulo. Aseg�rate de que est�s pasando un Canvas v�lido.");
            return;
        }

        uiCanvas = newCanvas;

        // Asignar el Text de los huevos
        eggText = uiCanvas.GetComponentInChildren<Text>(); // Busca el Text de los huevos
        if (eggText == null)
        {
            Debug.LogError("No se encontr� el componente de texto 'eggText'. Aseg�rate de que hay un componente Text en el Canvas.");
        }

        // Asignar el Text del mensaje
        Transform messageTransform = uiCanvas.transform.Find("MessageText");
        if (messageTransform != null)
        {
            messageText = messageTransform.GetComponent<Text>();
            if (messageText == null)
            {
                Debug.LogError("No se encontr� el componente de texto 'MessageText'. Aseg�rate de que hay un componente Text con este nombre en el Canvas.");
            }
        }
        else
        {
            Debug.LogError("No se encontr� el objeto 'MessageText' en el Canvas. Aseg�rate de que el objeto existe.");
        }

        UpdateEasterEggUI(); // Actualiza el UI
    }
}
