using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dice : ScriptableObject,ICloneable
{
   [SerializeField] [Range(1,20)] private int _numberRolls;
    [SerializeField] private int _diceValue;

    public Dice(int rolls,int value)
    {
        if(rolls > 0 && value > 0 && value % 2 == 0)
        {
            _numberRolls = rolls;
            _diceValue = value;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public int NumberRolls { get => _numberRolls;}
    public int DiceValue { get => _diceValue; }

    public object Clone()
    {
        return new Dice(NumberRolls, DiceValue);
    }

    public int RollDice(int modifier)
    {
        int result = modifier;
        for(int i =0 ; i < _numberRolls; i++)
        {
            result += UnityEngine.Random.Range(1,_diceValue);
        }
        return result;
    }
}
