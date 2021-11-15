using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dice
{
    private int _numberRolls;
    private int _diceValue;

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
