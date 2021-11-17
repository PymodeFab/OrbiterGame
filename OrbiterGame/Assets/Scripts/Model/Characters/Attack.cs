using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="New Attack",menuName ="Attack")]
public class Attack : ScriptableObject,ICloneable
{

    [SerializeField] private string _name;
    [SerializeField] [TextArea] private string _desc;
    [Header("Details")]
    [SerializeField] private Dice _damages;
    [SerializeField] private int _modifierToDamage;

    public Attack(string n, string d, Dice da, int modDa)
    {
        if(n is null || d is null || da is null)
        {
            throw new ArgumentException();
        }
        else
        {
            this._name = n;
            this._desc = d;
            this._damages = (Dice)da.Clone();
            this._modifierToDamage = modDa;
        }
    }

    public string Name { get => _name; set => _name = value; }
    public string Desc { get => _desc; set => _desc = value; }
    public Dice Damages { get => _damages; set => _damages = value; }
    public int ModifierToDamage { get => _modifierToDamage; set => _modifierToDamage = value; }

    public object Clone()
    {
        return new Attack((string)Name.Clone(),(string)Desc.Clone(),(Dice)Damages.Clone(),ModifierToDamage);
    }
}