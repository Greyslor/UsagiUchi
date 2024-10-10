using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Canvas shopCanvas; // Arrastra aqu� el Canvas de la tienda desde el Inspector

    void Start()
    {
        // Asignar el Canvas y componentes al GameManager
        GameManager.instance.AssignUIComponents(shopCanvas);
    }

    public void BuyAlfalfa()
    {
        GameManager.instance.BuyItem("alfalfa");
    }

    public void BuyAlmohada()
    {
        GameManager.instance.BuyItem("almohada");
    }

    public void BuyZanahoria()
    {
        GameManager.instance.BuyItem("zanahoria");
    }

    public void BuyCorral()
    {
        GameManager.instance.BuyItem("corral");
    }
}
