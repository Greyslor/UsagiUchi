using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Asignar desde el Inspector
    public Canvas uiCanvas; // El canvas que contiene el texto de los huevos
    public Text eggText; // El componente de texto donde se mostrar� el contador
    public Text messageText; // Texto para mostrar mensajes de error o �xito en la tienda

    public int totalEasterEggs = 0; // Contador de huevos de pascua

    // Precios de los objetos en la tienda
    private int alfalfaPrice = 4;
    private int almohadaPrice = 18;
    private int zanahoriaPrice = 5;
    private int corralPrice = 24;

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

    void Start()
    {
        LoadProgress(); // Cargar progreso al iniciar
    }

    private void OnApplicationQuit()
    {
        SaveProgress(); // Guardar progreso al salir de la aplicaci�n
    }

    // M�todo para a�adir huevos de pascua al total
    public void AddEasterEgg(int amount)
    {
        totalEasterEggs += amount;
        Debug.Log("Huevos de Pascua totales: " + totalEasterEggs);
        UpdateEasterEggUI(); // Actualiza el texto del UI
    }

    // M�todo para actualizar el texto de los huevos en la UI
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

    // M�todo para guardar el progreso
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("EasterEggs", totalEasterEggs);
        PlayerPrefs.Save();
    }

    // M�todo para cargar el progreso
    public void LoadProgress()
    {
        totalEasterEggs = PlayerPrefs.GetInt("EasterEggs", 0);
        Debug.Log("Progreso cargado. Huevos de Pascua: " + totalEasterEggs);
        UpdateEasterEggUI(); // Actualiza el UI despu�s de cargar los huevos
    }

    // M�todo para comprar un objeto de la tienda
    public void BuyItem(string itemName)
    {
        int price = 0;

        switch (itemName)
        {
            case "alfalfa":
                price = alfalfaPrice;
                break;
            case "almohada":
                price = almohadaPrice;
                break;
            case "zanahoria":
                price = zanahoriaPrice;
                break;
            case "corral":
                price = corralPrice;
                break;
            default:
                Debug.LogError("Objeto desconocido en la tienda.");
                return;
        }

        if (totalEasterEggs >= price)
        {
            totalEasterEggs -= price;
            UpdateEasterEggUI(); // Actualizar el contador de huevos en la UI
            messageText.text = "�Has comprado " + itemName + "!";
            Debug.Log("Has comprado: " + itemName);
        }
        else
        {
            messageText.text = "No tienes suficientes huevos de pascua para comprar " + itemName + ".";
            Debug.Log("No tienes suficientes huevos de pascua para comprar: " + itemName);
        }
    }

    // M�todo para asignar componentes cuando sea necesario
    public void AssignUIComponents(Canvas newCanvas)
    {
        uiCanvas = newCanvas;
        eggText = uiCanvas.GetComponentInChildren<Text>(); // Busca el Text dentro del Canvas
        UpdateEasterEggUI(); // Actualiza el UI
    }
}
