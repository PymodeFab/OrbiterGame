using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public Inventory(List<Item> it)
    {
        if(it is null)
        {
            throw new System.ArgumentException();
        }
        else
        {
            items = new List<Item>(it);
        }
    }

    public List<Item> Items { get => items; }
}