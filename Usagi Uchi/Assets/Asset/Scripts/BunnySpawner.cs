using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawner : MonoBehaviour
{
    public GameObject[] bunnies; 
    public Transform[] puntosDeSpawn; 
    public GameObject comida; 
    public float probabilidadAparicion = 0.01f; 

    void Update()
    {
        if (comida != null && Random.value < probabilidadAparicion)
        {
            SpawnBunny();
        }
    }

    void SpawnBunny()
    {
        int indexBunny = Random.Range(0, bunnies.Length);

        
        int indexPosicion = Random.Range(0, puntosDeSpawn.Length);

        
        Instantiate(bunnies[indexBunny], puntosDeSpawn[indexPosicion].position, Quaternion.identity);
    }
}
