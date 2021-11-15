using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class FC : Character
{
    protected FC(string name, string desc, Sprite s) : base(name, desc, s)
    {
    }
}
