using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stats",menuName ="Stats")]
[Serializable]
public class Stats : ScriptableObject,ICloneable
{

    [SerializeField] [Range(0,500)] private int _constitution;
    [SerializeField] [Range(0, 500)] private int _dexterity;
    [SerializeField] [Range(0, 500)] private int _wisdom;
    [SerializeField] [Range(0, 500)] private int _intelligence;
    [SerializeField] [Range(0, 500)] private int _strength;

    public Stats()
    {
        this._constitution = 0;
        this._dexterity = 0;
        this._wisdom = 0;
        this._intelligence = 0;
        this._strength = 0;
    }

    public Stats(int cons,int dex,int stre, int wisd, int intell)
    {
        if(VerifyStat(cons) && VerifyStat(dex) && VerifyStat(stre) && VerifyStat(wisd) && VerifyStat(intell))
        {
            this._constitution = cons;
            this._dexterity = dex;
            this._strength = stre;
            this._wisdom = wisd;
            this._intelligence = intell;
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    public int Constitution { get => _constitution;
        set
        {
            if (_constitution + value < 0)
            {
                _constitution = 0;
            }else if(_constitution + value > 500)
            {
                _constitution = 500;
            }
            else
            {
                _constitution += value;
            }
        }
    }
    public int Dexterity { get => _dexterity; set
        {
            if (_dexterity + value < 0)
            {
                _dexterity = 0;
            }
            else if (_dexterity + value > 500)
            {
                _dexterity = 500;
            }
            else
            {
                _dexterity += value;
            }
        }
    }
    public int Wisdom { get => _wisdom; set
        {
            if (_wisdom + value < 0)
            {
                _wisdom = 0;
            }
            else if (_wisdom + value > 500)
            {
                _wisdom = 500;
            }
            else
            {
                _wisdom += value;
            }
        }
    }
    public int Intelligence { get => _intelligence; set
        {
            if (_intelligence + value < 0)
            {
                _intelligence = 0;
            }
            else if (_intelligence + value > 500)
            {
                _intelligence = 500;
            }
            else
            {
                _intelligence += value;
            }
        }
    }
    public int Strength { get => _strength; set
        {
            if (_strength + value < 0)
            {
                _strength = 0;
            }
            else if (_strength + value > 500)
            {
                _strength = 500;
            }
            else
            {
                _strength += value;
            }
        }
    }

    private bool VerifyStat(int s)
    {
        return 0 < s && s < 500;
    }

    public object Clone()
    {
        return new Stats(Constitution,Dexterity,Strength,Wisdom,Intelligence);
    }

    public static bool operator >=(Stats s1, Stats s2) => s1.Constitution >= s2.Constitution && s1.Dexterity >= s2.Dexterity && s1.Intelligence >= s2.Intelligence && s1.Wisdom >= s2.Wisdom && s1.Strength >= s2.Strength;
    public static bool operator <=(Stats s1, Stats s2) => s1.Constitution <= s2.Constitution && s1.Dexterity <= s2.Dexterity && s1.Intelligence <= s2.Intelligence && s1.Wisdom <= s2.Wisdom && s1.Strength <= s2.Strength;
}
