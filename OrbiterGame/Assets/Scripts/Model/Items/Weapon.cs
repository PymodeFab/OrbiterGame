using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon",menuName ="Item/Equipment/Weapon")]
public class Weapon : Equipment
{
    [SerializeField] private DamageType _dType;
    [SerializeField] private WeaponType _wType;
    [SerializeField] private double _range;
    [SerializeField] private double _attackSpeed;

    public Weapon(string n, string d, Sprite s, int v, int w, Stats st) : base(n, d, s, v, w, st)
    {
    }
}
