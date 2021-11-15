using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New NPC", menuName = "Character/NPC")]
public class NPC : Character
{
    [SerializeField] [TextArea] private List<String> _dialogs;
    public NPC(string name, string desc, Sprite s,List<String> dial) : base(name, desc, s)
    {
        if(dial is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            _dialogs = new List<string>(dial);
        }
    }

    public List<String> Dialogs { get => new List<String>(_dialogs);}

    public override object Clone()
    {
        List<string> dial = new List<string>();
        foreach(string s in Dialogs)
        {
            dial.Add((string)s.Clone());
        }
        NPC nps = new NPC((string)Name.Clone(), (string)Description.Clone(), Sprite, dial);
        return nps;
    }
}
