using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    public int totalHuevos = 0; // Contador de huevos
    public Text contadorHuevosText; // Asigna el texto del contador en el Canvas

    public void AgregarHuevo()
    {
        totalHuevos++;
        ActualizarContador(); // Actualizar el contador en la UI
    }

    void ActualizarContador()
    {
        contadorHuevosText.text = "" + totalHuevos; // Actualiza el texto
    }
}
