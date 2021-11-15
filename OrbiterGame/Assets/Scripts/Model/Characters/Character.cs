using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class which represents every Character seen in the game
 * 
 * Date : 15/11/2021
 * Author : Dompey Fabien
 * Version : 1.0.0
 */
[System.Serializable]
public abstract class Character : ScriptableObject,System.ICloneable
{

    [SerializeField] private string _name;
    [SerializeField] [TextArea] private string _description;
    [SerializeField] private Sprite _sprite;

    public Character(string name,string desc,Sprite s)
    {
        if(name is null || desc is null || s is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            this._name = name;
            this._description = desc;
            this._sprite = s;
        }
    }

    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public virtual object Clone()
    {
        return this.Clone();
    }
}
