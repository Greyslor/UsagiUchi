using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Salvar
        //Obtener
         int edad = PlayerPrefs.GetInt("edad", 21);
         print(edad);
        string rute = Application.dataPath + "/StreamingAssets/heroclass.json";

        /*HeroClass greys = new HeroClass("greys", 21, 20, 2);

        print(greys.life);

        string json = JsonUtility.ToJson(greys, true);

        print(json);

        string rute = Application.dataPath + "/StreamingAssets/heroclass.json";

        File.WriteAllText(rute, json);*/

        /*string json = File.ReadAllText(rute);
        HeroClass hero = JsonUtility.FromJson<HeroClass>(json);
        print(hero.name);

        hero.name = "Gohan";
        print(hero.name);*/

        HeroClass[] heroes = new HeroClass[2];

        heroes[0] = new HeroClass("Milk", 2, 2, 15);
        heroes[1] = new HeroClass("Bulma", 2, 2, 18);

        string json = JsonHelper.ToJson(heroes, true);
        string ruteArray = Application.dataPath + "/StreamingAssets/Heroes.json";
        File.WriteAllText(ruteArray, json);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
