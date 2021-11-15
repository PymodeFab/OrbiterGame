using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class MagicalItem : Item,ISMagical
{
    [SerializeField] private MagicalEffect _effect;
    protected MagicalItem(string n, string d, Sprite s, int v, int w,MagicalEffect m) : base(n, d, s,v,w)
    {
        if(m is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._effect = m;
        }
    }

    public MagicalEffect GetMagicalEffect()
    {
        return _effect;
    }
}
