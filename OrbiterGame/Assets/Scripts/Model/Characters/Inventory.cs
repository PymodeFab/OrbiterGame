using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Inventory :ICloneable
{
    private readonly Dictionary<Item, int> dicoItemsNumber;

    private static int capacity = 100;

    private int _slotsUsed;

    public Inventory()
    {
        dicoItemsNumber = new Dictionary<Item, int>();
        _slotsUsed = 0;
    }

    public Inventory(List<Item> it)
    {
        if(it is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            _slotsUsed = 0;
            dicoItemsNumber = new Dictionary<Item, int>();
            foreach(Item i in it)
            {
                AddItem(i);
            }
        }
    }

    public Inventory(Dictionary<Item,int> dico)
    {
        if (dico is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            dicoItemsNumber = new Dictionary<Item, int>(dico);
        }
    }

    public bool IsPossessed(Item i)
    {
        return dicoItemsNumber.ContainsKey(i);
    }

    public List<Item> Items { get => dicoItemsNumber.Keys.ToList(); }
    public static int Capacity { get => capacity; }

    public void AddItem(Item i)
    {
        AddItems(i, 1);
    }

    public void AddItems(Item i, int numberOfItems)
    {
        if (!(i is null) && _slotsUsed + i.Weight * numberOfItems <= capacity)
        {
            if (dicoItemsNumber.ContainsKey(i))
            {
                dicoItemsNumber[i] += numberOfItems;
            }
            else
            {
                dicoItemsNumber.Add(i, numberOfItems);
            }
            _slotsUsed += i.Weight * numberOfItems;
        }
    }

    public int GetNumberOfItem(Item i)
    {
        int result = 0;
        if (!(i is null))
        {
            if (dicoItemsNumber.ContainsKey(i))
            {
                result = dicoItemsNumber[i];
            }
        }
        return result;
    }

    public void RemoveItem(Item i)
    {
        RemoveItems(i, 1);
    }

    public void RemoveItems(Item i, int numberOfItems)
    {
        if (!(i is null))
        {
            if (dicoItemsNumber.ContainsKey(i))
            {
                if(dicoItemsNumber[i] > numberOfItems)
                {

                    dicoItemsNumber[i] -= numberOfItems;
                }
                else
                {
                    dicoItemsNumber.Remove(i);
                }

                _slotsUsed -= i.Weight * numberOfItems;
            }
        }
    }

    public object Clone()
    {
        List<Item> cloned = new List<Item>();
        foreach(Item i in Items)
        {
            cloned.Add((Item)i.Clone());
        }
        return new Inventory(cloned);
    }

    internal bool CanBeAdded(List<Item> old)
    {
        int weight = 0;
        foreach(Item i in old)
        {
            weight += i.Weight;
        }
        return _slotsUsed + weight <= capacity;
    }
}