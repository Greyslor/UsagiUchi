using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggManager : MonoBehaviour
{
    public int eggs = 100;
    public TextMeshProUGUI eggsTexto;
     
    void Start()
    {
        ActualizarEggs();
    }

    public void ActualizarEggs()
    {
        eggsTexto.text = "" + eggs;
    }

    public void GanarEggs(int cantidad)
    {
        eggs += cantidad;
        ActualizarEggs();
    }
}
