using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatStats
{
    public static int GetModifierForWeapon(FC user, IDamage weapon)
    {
        switch (weapon.GetWeaponType())
        {
            case WeaponType.AXE:
                return user.Stats.Strength;
            case WeaponType.BOW:
                return user.Stats.Dexterity;
            case WeaponType.DAGGER:
                return user.Stats.Dexterity;
            case WeaponType.HAMMER:
                return user.Stats.Strength;
            case WeaponType.LONGSWORD:
                return user.Stats.Strength;
            case WeaponType.MACE:
                return user.Stats.Strength;
            case WeaponType.SPEAR:
                return user.Stats.Dexterity;
            case WeaponType.STAFF:
                return user.Stats.Dexterity;
            case WeaponType.SWORD:
                return user.Stats.Dexterity > user.Stats.Strength ? user.Stats.Dexterity : user.Stats.Strength;
        }
        throw new System.Exception();
    }
}
