using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armor : Equipment, IProtect
{
    public Armor(string n, string d, Sprite s, int v, int w, Stats st, BodyPartEquipped bp) : base(n, d, s, v, w, st, bp)
    {
    }

    public int GetArmor()
    {
        int armor = 0;
        switch (_partEquipped)
        {
            case BodyPartEquipped.ONE_HAND:
                armor = 10;
                break;
            case BodyPartEquipped.HEAD:
                armor = 5;
                break;
            case BodyPartEquipped.LEGS:
                armor = 15;
                break;
            case BodyPartEquipped.TORSO:
                armor = 30;
                break;
        }
        return armor;
    }

    public override object Clone()
    {
        Armor a = new Armor((string)(Name.Clone()), (string)(Desc.Clone()), Sprite, Value, Weight, (Stats)(Requirements.Clone()), GetPartEquipped());
        return a;
    }
}
