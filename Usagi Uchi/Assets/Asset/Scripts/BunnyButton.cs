using UnityEngine;
using UnityEngine.UI;

public class BunnyButton : MonoBehaviour
{
    public EggManager eggManager; 

    void Start()
    {
        
        Button button = GetComponent<Button>();
        button.onClick.AddListener(DarHuevo);
    }

    void DarHuevo()
    {
        
        eggManager.AgregarHuevo();
    }
}
