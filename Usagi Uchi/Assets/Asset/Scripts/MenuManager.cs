using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // M�todo para cargar la escena del men� principal
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia "NombreDeTuEscenaMenu" por el nombre real de tu escena de men�
    }
}
