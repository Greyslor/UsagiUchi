using System.Collections.Generic;
using UnityEngine;

public class ConejoSpawner : MonoBehaviour
{
    public GameObject[] rabbitPrefabs; // Los prefabs de conejos (8 tipos)
    public Transform[] spawnPoints; // Los puntos de spawn
    public int maxRabbits = 10; // Límite de conejos en pantalla
    public float spawnInterval = 10f; // Intervalo para revisar spawns
    public float rabbitLifetime = 15f; // Tiempo de vida de cada conejo

    private List<GameObject> activeRabbits = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("TrySpawnRabbit", 2f, spawnInterval);
    }

    void TrySpawnRabbit()
    {
        if (activeRabbits.Count < maxRabbits)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            if (spawnPoint != null)
            {
                GameObject rabbit = Instantiate(GetRandomRabbit(), spawnPoint.position, Quaternion.identity);
                rabbit.transform.parent = spawnPoint; // Establece el spawn como padre del conejo
                activeRabbits.Add(rabbit);
                Destroy(rabbit, rabbitLifetime); // Elimina el conejo después de un tiempo
            }
        }
    }

    Transform GetRandomSpawnPoint()
    {
        List<Transform> availableSpawns = new List<Transform>();
        foreach (Transform spawn in spawnPoints)
        {
            if (spawn.childCount == 0) // No hay conejo en este spawn
            {
                availableSpawns.Add(spawn);
            }
        }

        if (availableSpawns.Count > 0)
        {
            return availableSpawns[Random.Range(0, availableSpawns.Count)];
        }

        return null; // No hay spawns disponibles
    }

    GameObject GetRandomRabbit()
    {
        return rabbitPrefabs[Random.Range(0, rabbitPrefabs.Length)];
    }
}