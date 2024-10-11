using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        // Verifica si ya existe otra instancia de MusicManager
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject); // Si ya existe, destruye este objeto
        }
        else
        {
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
    }
}
