using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    public float tiempoDeEspera = 3f; // Tiempo en segundos para simular la carga

    void Start()
    {
        Invoke("CargarMenuPrincipal", tiempoDeEspera); // Llama al método después del tiempo de espera
    }

    void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia a la escena del menú principal
    }
}
