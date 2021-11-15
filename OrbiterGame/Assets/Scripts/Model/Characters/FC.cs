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


    protected FC(string name, string desc, Sprite s,int maxHP,int maxFort,Stats st) : base(name, desc, s)
    {
        if(maxHP <= 0 || maxFort <= 0 || st is null)
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
}
