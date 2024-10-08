using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public Camera mainCamera;      // La c�mara principal
    public float scrollSpeed = 0.5f; // Velocidad de desplazamiento
    public float minX, maxX;        // L�mites del jard�n en el eje X

    private Vector3 touchStart;

    void Update()
    {
        // Detectar el toque inicial
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        // Detectar el movimiento del dedo para hacer el desplazamiento
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mainCamera.transform.position += new Vector3(direction.x * scrollSpeed, 0, 0);

            // Limitar el movimiento de la c�mara dentro del escenario
            float clampedX = Mathf.Clamp(mainCamera.transform.position.x, minX, maxX);
            mainCamera.transform.position = new Vector3(clampedX, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}
