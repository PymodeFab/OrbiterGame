using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Equipment : Item, ISEquippable
{
    [SerializeField] private Stats _requirements;
    [SerializeField] protected BodyPartEquipped _partEquipped;
    public Equipment(string n, string d, Sprite s, int v, int w,Stats st,BodyPartEquipped bp) : base(n, d, s, v, w)
    {
        if(s is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._requirements = st;
            this._partEquipped = bp;
        }
    }
    protected Stats Requirements { get => _requirements; }

    public bool CanBeEquipped(Stats s)
    {
        return s >= _requirements;
    }

    public BodyPartEquipped GetPartEquipped()
    {
        return _partEquipped;
    }
}
