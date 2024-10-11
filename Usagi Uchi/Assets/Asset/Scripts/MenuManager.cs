using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // Método para cargar la escena del menú principal
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia "NombreDeTuEscenaMenu" por el nombre real de tu escena de menú
    }
}
