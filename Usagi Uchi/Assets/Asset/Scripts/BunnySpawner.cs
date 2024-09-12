using System;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawner : MonoBehaviour
{
    public GameObject[] bunnies; // Array de prefabs de conejos
    public Transform[] puntosDeSpawn; // Puntos de aparición en la escena
    public float probabilidadAparicion = 0.05f; // Probabilidad de aparición en cada verificación
    public List<string> registroConejos = new List<string>(); // Registro de conejos que han visitado

    private DateTime lastExitTime; // Tiempo de última vez que la app se cerró
    private List<GameObject> conejosActuales = new List<GameObject>(); // Conjunto de conejos que están actualmente en escena

    void Start()
    {
        // Cargar la hora de última salida
        CargarTiempoUltimaSalida();

        // Cargar el registro de conejos
        CargarRegistro();

        // Verificar cuánto tiempo ha pasado y cambiar la cantidad de conejos en el jardín
        ManejarConejosAlVolver();
    }

    void Update()
    {
        // Simular aparición de conejos si la probabilidad se cumple
        if (UnityEngine.Random.value < probabilidadAparicion)
        {
            SpawnBunny();
        }
    }

    // Función para la aparición de conejos
    void SpawnBunny()
    {
        if (conejosActuales.Count < puntosDeSpawn.Length)
        {
            int indexBunny = UnityEngine.Random.Range(0, bunnies.Length); // Elegir conejo aleatorio
            int indexPosicion = UnityEngine.Random.Range(0, puntosDeSpawn.Length); // Posición aleatoria

            // Instanciar el conejo en una posición aleatoria
            GameObject nuevoConejo = Instantiate(bunnies[indexBunny], puntosDeSpawn[indexPosicion].position, Quaternion.identity);
            conejosActuales.Add(nuevoConejo);

            // Agregar el nombre del conejo al registro
            AgregarAlRegistro(bunnies[indexBunny].name);
        }
    }

    // Guardar el registro de conejos en PlayerPrefs
    void GuardarRegistro()
    {
        for (int i = 0; i < registroConejos.Count; i++)
        {
            PlayerPrefs.SetString("conejo_" + i, registroConejos[i]);
        }
        PlayerPrefs.SetInt("totalConejos", registroConejos.Count);
        PlayerPrefs.Save();
    }

    // Cargar el registro de conejos desde PlayerPrefs
    void CargarRegistro()
    {
        int totalConejos = PlayerPrefs.GetInt("totalConejos", 0);
        for (int i = 0; i < totalConejos; i++)
        {
            string nombreConejo = PlayerPrefs.GetString("conejo_" + i);
            registroConejos.Add(nombreConejo);
        }
    }

    // Agregar el nombre del conejo al registro si no está ya
    void AgregarAlRegistro(string nombreConejo)
    {
        if (!registroConejos.Contains(nombreConejo))
        {
            registroConejos.Add(nombreConejo);
            GuardarRegistro(); // Guardar el registro actualizado
        }
    }

    // Guardar el tiempo de salida para cuando el jugador cierra la app
    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastExitTime", DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    // Cargar la última vez que se cerró la app
    void CargarTiempoUltimaSalida()
    {
        string lastExitString = PlayerPrefs.GetString("lastExitTime", DateTime.Now.ToString());
        lastExitTime = DateTime.Parse(lastExitString);
    }

    // Manejar la aparición de nuevos conejos o desaparición basada en el tiempo transcurrido
    void ManejarConejosAlVolver()
    {
        TimeSpan tiempoFuera = DateTime.Now - lastExitTime;

        // Ejemplo: si han pasado más de 10 minutos, cambiar conejos
        if (tiempoFuera.TotalMinutes > 10)
        {
            // Eliminar conejos actuales
            foreach (GameObject conejo in conejosActuales)
            {
                Destroy(conejo);
            }
            conejosActuales.Clear();

            // Aparecer nuevos conejos
            for (int i = 0; i < puntosDeSpawn.Length; i++)
            {
                if (UnityEngine.Random.value < 0.5f) // 50% de probabilidad de aparición de un nuevo conejo
                {
                    SpawnBunny();
                }
            }
        }
    }
}
