using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item, ISEquippable
{
    [SerializeField] protected Stats _requirements;
    public Equipment(string n, string d, Sprite s, int v, int w,Stats st) : base(n, d, s, v, w)
    {
        if(s is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._requirements = st;
        }
    }

    public bool CanBeEquipped(Stats s)
    {
        return s >= _requirements;
    }
}
