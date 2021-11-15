using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class which represents every item in the game
 * Date : 15/11/2021
 * Author : Dompey Fabien
 * Version : 1.0.0
 */
public abstract class Item : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] [TextArea] private string _desc;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _value;
    [SerializeField] private int _weight;

    public Item(string n, string d,Sprite s,int v,int w)
    {
        if((n is null || d is null || s is null) && v > 0 && w > 0)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._name = n;
            this._desc = d;
            this._sprite = s;
            this._weight = w;
            this._value = v;
        }
    }

    public string Name { get => _name; set => _name = value; }
    public string Desc { get => _desc; set => _desc = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
}
