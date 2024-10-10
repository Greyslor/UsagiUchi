using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;
    float hInput, vInput;

    int score = 0;
    public int winScore;

    public GameObject winPanel;  // Panel que se muestra cuando ganas (contiene botón "Aceptar")
    public GameObject losePanel; // Panel que se muestra cuando pierdes (contiene botón "Aceptar")

    private GameManager gameManager; // Referencia al GameManager para añadir los huevos

    void Start()
    {
        // Usamos FindAnyObjectByType para evitar la advertencia
        gameManager = Object.FindAnyObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("No se encontró el GameManager en la escena.");
        }

        // Desactivamos ambos paneles al inicio
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            score++;
            Destroy(collision.gameObject);

            if (score >= winScore)
            {
                WinGame(); // Mostrar el panel de ganar
            }
        }
        else if (collision.gameObject.tag == "Chocolate")
        {
            LoseGame(); // Mostrar el panel de perder
        }
    }

    void WinGame()
    {
        winPanel.SetActive(true); // Muestra el panel de ganar (junto con el botón)
        gameManager.AddEasterEgg(1); // Añade un huevo de pascua
    }

    void LoseGame()
    {
        losePanel.SetActive(true); // Muestra el panel de perder (junto con el botón)
        // No se añaden huevos de pascua en caso de perder
    }

    // Este método lo llamarás desde el botón "Aceptar" de ambos paneles
    public void ReturnToGarden()
    {
        // Regresar a la escena del jardín
        SceneManager.LoadScene("Garden");
    }
}
