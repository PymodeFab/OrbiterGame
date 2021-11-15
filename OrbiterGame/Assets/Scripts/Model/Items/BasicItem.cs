using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New Basic Item",menuName ="Item/Basic Item")]
public class BasicItem : Item
{
    public BasicItem(string n, string d, Sprite s, int v, int w) : base(n, d, s, v, w)
    {
    }
    public override object Clone()
    {
        BasicItem b = new BasicItem((string)Name.Clone(), (string)Desc.Clone(), Sprite, Value, Weight);
        return b;
    }

}
