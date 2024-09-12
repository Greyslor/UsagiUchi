using System;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawner : MonoBehaviour
{
    public GameObject[] bunnies;
    public Transform[] puntosDeSpawn;
    public float probabilidadAparicion = 0.05f;
    public List<string> registroConejos = new List<string>();

    private DateTime lastExitTime;
    private List<GameObject> conejosActuales = new List<GameObject>();

    void Start()
    {
       
        CargarTiempoUltimaSalida();

        CargarRegistro();

        ManejarConejosAlVolver();
    }

    void Update()
    {
        if (UnityEngine.Random.value < probabilidadAparicion)
        {
            SpawnBunny();
        }
    }

    void SpawnBunny()
    {
        if (conejosActuales.Count < puntosDeSpawn.Length)
        {
            int indexBunny = UnityEngine.Random.Range(0, bunnies.Length); 
            int indexPosicion = UnityEngine.Random.Range(0, puntosDeSpawn.Length);

            GameObject nuevoConejo = Instantiate(bunnies[indexBunny], puntosDeSpawn[indexPosicion].position, Quaternion.identity);
            conejosActuales.Add(nuevoConejo);

            AgregarAlRegistro(bunnies[indexBunny].name);
        }
    }

    void GuardarRegistro()
    {
        for (int i = 0; i < registroConejos.Count; i++)
        {
            PlayerPrefs.SetString("conejo_" + i, registroConejos[i]);
        }
        PlayerPrefs.SetInt("totalConejos", registroConejos.Count);
        PlayerPrefs.Save();
    }

    void CargarRegistro()
    {
        int totalConejos = PlayerPrefs.GetInt("totalConejos", 0);
        for (int i = 0; i < totalConejos; i++)
        {
            string nombreConejo = PlayerPrefs.GetString("conejo_" + i);
            registroConejos.Add(nombreConejo);
        }
    }

    void AgregarAlRegistro(string nombreConejo)
    {
        if (!registroConejos.Contains(nombreConejo))
        {
            registroConejos.Add(nombreConejo);
            GuardarRegistro(); 
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastExitTime", DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    void CargarTiempoUltimaSalida()
    {
        string lastExitString = PlayerPrefs.GetString("lastExitTime", DateTime.Now.ToString());
        lastExitTime = DateTime.Parse(lastExitString);
    }

    void ManejarConejosAlVolver()
    {
        TimeSpan tiempoFuera = DateTime.Now - lastExitTime;

        if (tiempoFuera.TotalMinutes > 10)
        {
            foreach (GameObject conejo in conejosActuales)
            {
                Destroy(conejo);
            }
            conejosActuales.Clear();

            for (int i = 0; i < puntosDeSpawn.Length; i++)
            {
                if (UnityEngine.Random.value < 0.5f) 
                {
                    SpawnBunny();
                }
            }
        }
    }
}
