using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Opciones Generales")]
    [SerializeField] int volumenMusica;
    [SerializeField] int volumenSonido;
    [SerializeField] GameObject pantallaMenu;
    [SerializeField] GameObject pantallaOciones;
    [SerializeField] float tiempoCambiaOpcion;

    [Header("Elementos de menu")]
    [SerializeField] SpriteRenderer comenzar;
    [SerializeField] SpriteRenderer opciones;
    [SerializeField] SpriteRenderer salir;

    [Header("Elementos de opciones")]
    [SerializeField] SpriteRenderer musica;
    [SerializeField] SpriteRenderer sonido;
    [SerializeField] SpriteRenderer volver;

    [Header("Sprites de menu")]
    [SerializeField] Sprite comenzar_off;
    [SerializeField] Sprite comenzar_on;
    [SerializeField] Sprite opciones_off;
    [SerializeField] Sprite opciones_on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
