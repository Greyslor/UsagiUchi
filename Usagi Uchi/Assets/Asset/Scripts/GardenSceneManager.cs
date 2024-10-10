using UnityEngine;

public class GardenSceneManager : MonoBehaviour
{
    private void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>(); // Encuentra el Canvas en esta escena
        if (canvas != null && GameManager.instance != null)
        {
            GameManager.instance.AssignUIComponents(canvas); // Asigna el Canvas y el Text al GameManager
        }
    }
}
