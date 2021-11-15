using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MagicalArmor : MagicalEquipment, IProtect
{
    public MagicalArmor(string n, string d, Sprite s, int v, int w, Stats st,MagicalEffect m, BodyPartEquipped bp) : base(n, d, s, v, w, st,m, bp)
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
        MagicalArmor m = new MagicalArmor((string)(Name.Clone()), (string)(Desc.Clone()), Sprite, Value, Weight, (Stats)(Requirements.Clone()), GetMagicalEffect(), GetPartEquipped());
        return m;
    }
}