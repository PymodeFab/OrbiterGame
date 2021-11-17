using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Weapon",menuName ="Item/Equipment/Weapon")]
public class Weapon : Equipment,IDamage
{
    [SerializeField] private DamageType _dType;
    [SerializeField] private WeaponType _wType;

    public WeaponType GetWeaponType() => _wType;

    public Weapon(string n, string d, Sprite s, int v, int w, Stats st,DamageType dtype,WeaponType wtype) : base(n, d, s, v, w, st,BodyPartEquipped.ONE_HAND)
    {
        this._dType = dtype;
        this._wType = wtype;
        if(wtype == WeaponType.AXE || wtype == WeaponType.BOW || wtype == WeaponType.HAMMER || wtype == WeaponType.LONGSWORD || wtype == WeaponType.SPEAR || wtype == WeaponType.STAFF)
        {
            _partEquipped = BodyPartEquipped.TWO_HAND;
        }
    }

    public Dice GetDamagesRoll()
    {
        Dice d = null;
        switch (_wType)
        {
            case WeaponType.SPEAR:
                d = new Dice(1,6);
                break;
            case WeaponType.BOW:
                d = new Dice(1, 8);
                break;
            case WeaponType.SWORD:
                d = new Dice(1, 6);
                break;
            case WeaponType.HAMMER:
                d = new Dice(1, 10);
                break;
            case WeaponType.LONGSWORD:
                d = new Dice(2, 6);
                break;
            case WeaponType.MACE:
                d = new Dice(1, 6);
                break;
            case WeaponType.AXE:
                d = new Dice(1, 12);
                break;
            case WeaponType.STAFF:
                d = new Dice(1, 6);
                break;
            case WeaponType.DAGGER:
                d = new Dice(1, 4);
                break;
        }
        return d;
    }

    public int GetRange()
    {
        int range = 0;
        switch (_wType)
        {
            case WeaponType.SPEAR:
                range = 3;
                break;
            case WeaponType.BOW:
                range = 6;
                break;
            case WeaponType.SWORD:
                range = 2;
                break;
            case WeaponType.HAMMER:
                range = 3;
                break;
            case WeaponType.LONGSWORD:
                range = 3;
                break;
            case WeaponType.MACE:
                range = 2;
                break;
            case WeaponType.AXE:
                range = 3;
                break;
            case WeaponType.STAFF:
                range = 2;
                break;
            case WeaponType.DAGGER:
                range = 1;
                break;
        }
        return range;
    }

    public double GetAttackSpeed()
    {
        double atts = 0;
        switch (_wType)
        {
            case WeaponType.SPEAR:
                atts = 1;
                break;
            case WeaponType.BOW:
                atts = 0.9 ;
                break;
            case WeaponType.SWORD:
                atts = 1.2;
                break;
            case WeaponType.HAMMER:
                atts = 0.8;
                break;
            case WeaponType.LONGSWORD:
                atts = 0.7;
                break;
            case WeaponType.MACE:
                atts = 1.2;
                break;
            case WeaponType.AXE:
                atts = 0.75;
                break;
            case WeaponType.STAFF:
                atts = 1.2;
                break;
            case WeaponType.DAGGER:
                atts = 2.5;
                break;
        }
        return atts;
    }

    public DamageType GetDamageType() => _dType;

    public override object Clone()
    {
        Weapon w = new Weapon((string)(Name.Clone()),(string) (Desc.Clone()), Sprite, Value, Weight,(Stats)(Requirements.Clone()), GetDamageType(), _wType);
        return w;
    }
}
