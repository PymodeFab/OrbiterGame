using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Hero", menuName = "Character/FC/Hero")]
public class Hero : FC
{
    public Hero(string name, string desc, Sprite s, int maxHP, int maxFort) : base(name, desc, s, maxHP, maxFort)
    {
    }
}
