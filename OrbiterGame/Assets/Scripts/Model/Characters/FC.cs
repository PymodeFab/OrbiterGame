using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class FC : Character
{
    [SerializeField] private int _maxHP;
    private int _currentHP;
    [SerializeField] private int _maxFortitude;
    private int _currentFortitude;
    [SerializeField] private Stats _stats;
    private Inventory _inventory;
    private Equipments _equipments;

    [SerializeField] private List<DamageType> _vulnerabilities;
    [SerializeField] private List<DamageType> _resistances;
    [SerializeField] private List<DamageType> _immunities;
    [SerializeField] private List<Attack> _attacks;


    protected FC(string name, string desc, Sprite s,int maxHP,int maxFort,Stats st,List<DamageType> res,List<DamageType> vuln,List<DamageType> imu,List<Attack> a) : base(name, desc, s)
    {
        if(maxHP <= 0 || maxFort <= 0 || st is null || vuln is null || res is null || imu is null || a is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._maxHP = maxHP;
            this._currentHP = maxHP;
            this._maxFortitude = maxFort;
            this._currentFortitude = maxFort;
            this._stats = st;
            _vulnerabilities = new List<DamageType>();
            _resistances = new List<DamageType>();
            _immunities = new List<DamageType>();
            foreach(DamageType d in res)
            {
                AddResistance(d);
            }
            foreach (DamageType d in vuln)
            {
                AddVulnerability(d);
            }
            foreach (DamageType d in imu)
            {
                AddImmunity(d);
            }
            _attacks = new List<Attack>(a);
            _inventory = new Inventory();
            _equipments = new Equipments();
        }
    }

    protected FC(string name, string desc, Sprite s, int maxHP, int maxFort) : base(name, desc, s)
    {
        if (maxHP <= 0 || maxFort <= 0)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._maxHP = maxHP;
            this._currentHP = maxHP;
            this._maxFortitude = maxFort;
            this._currentFortitude = maxFort;
            this._stats = new Stats();
            _vulnerabilities = new List<DamageType>();
            _resistances = new List<DamageType>();
            _immunities = new List<DamageType>();
            _attacks = new List<Attack>();
            _inventory = new Inventory();
            _equipments = new Equipments();
        }
    }

    public int CurrentHP { get => _currentHP; 
        set {
            if(_currentHP + value < 0)
            {
                _currentHP = 0;
            }else if(_currentHP + value > _maxHP)
            {
                _currentHP = _maxHP;
            }
            else
            {
                _currentHP += value;
            }
        } 
    }
    public int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int MaxFortitude { get => _maxFortitude; set => _maxFortitude = value; }
    public int CurrentFortitude { get => _currentFortitude; set
        {
            if (_currentFortitude + value < 0)
            {
                _currentFortitude = 0;
            }
            else if (_currentFortitude + value > _maxFortitude)
            {
                _currentFortitude = _maxFortitude;
            }
            else
            {
                _currentFortitude += value;
            }
        }
    }
    public Stats Stats { get => _stats;}
    public Inventory Inventory { get => _inventory; }
    public List<DamageType> Vulnerabilities { get => new List<DamageType>(_vulnerabilities); }
    public List<DamageType> Resistances { get => new List<DamageType>(_resistances); }
    public List<DamageType> Immunities { get => new List<DamageType>(_immunities); }
    public List<Attack> Attacks { get => _attacks; }

    public void EquipItem(Item i)
    {
        if (i is ISEquippable)
        {
            ISEquippable equip = (ISEquippable)i;
            List<Item> old = _equipments.GetItemsIfNewItemEquipped(i);
            if (equip.CanBeEquipped(Stats) && _inventory.CanBeAdded(old) && _equipments.EquipItem(i))
            {
                if (_inventory.IsPossessed(i))
                {
                    _inventory.RemoveItem(i);
                }
                foreach(Item item in old)
                {
                    _inventory.AddItem(item);
                }
                if(i is IDamage)
                {
                    IDamage weapon = (IDamage)i;
                    int modifier = 0;
                    modifier = CombatStats.GetModifierForWeapon(this, weapon);
                    _attacks.Add(new Attack(i.Name, weapon.GetDamagesRoll().NumberRolls + "d" + weapon.GetDamagesRoll().DiceValue + " + " + modifier, weapon.GetDamagesRoll(), modifier));
                    foreach(Item item in old)
                    {
                        _attacks.Remove(_attacks.Find(x => x.Name.Equals(item.Name)));
                    }
                }
                
            }

        }
    }

    public void AddResistance(DamageType t)
    {
        if (!_resistances.Contains(t))
        {
            if (_vulnerabilities.Contains(t))
            {
                _vulnerabilities.Remove(t);
            }else if (_immunities.Contains(t))
            {
                _immunities.Remove(t);
            }
            _resistances.Add(t);
        }
    }
    public void AddVulnerability(DamageType t)
    {
        if (!_vulnerabilities.Contains(t))
        {
            if (_resistances.Contains(t))
            {
                _resistances.Remove(t);
            }
            else if (_immunities.Contains(t))
            {
                _immunities.Remove(t);
            }
            _vulnerabilities.Add(t);
        }
    }
    public void AddImmunity(DamageType t)
    {
        if (!_immunities.Contains(t))
        {
            if (_vulnerabilities.Contains(t))
            {
                _vulnerabilities.Remove(t);
            }
            else if (_resistances.Contains(t))
            {
                _resistances.Remove(t);
            }
            _immunities.Add(t);
        }
    }

    public void RemoveResistance(DamageType d)
    {
        if (_resistances.Contains(d))
        {
            _resistances.Remove(d);
        }
    }
    public void RemoveVulnerability(DamageType d)
    {
        if (_vulnerabilities.Contains(d))
        {
            _vulnerabilities.Remove(d);
        }
    }
    public void RemoveImmunity(DamageType d)
    {
        if (_immunities.Contains(d))
        {
            _immunities.Remove(d);
        }
    }
}
