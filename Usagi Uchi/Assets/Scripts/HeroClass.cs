using System;
using UnityEngine;

[Serializable]
    public class HeroClass
    {
        public string name;
        public int life;
    public int mana;
    public int speed;


    public HeroClass(string name, int life, int mana, int speed)
    {
        this.name = name;
        this.life = life;
        this.mana = mana;
        this.speed = speed;
    }
    }

