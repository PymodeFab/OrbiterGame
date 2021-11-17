using System;
using System.Collections.Generic;

[Serializable]
public class Equipments : ICloneable
{
    private readonly ISEquippable[] items;
    private static readonly int capacity = 10;

    public Equipments()
    {
        items = new ISEquippable[capacity];
    }

    public Equipments(ISEquippable[] items)
    {
        if (!(items is null) && items.Length == capacity)
        {
            this.items = items;
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public object Clone()
    {
        ISEquippable[] clonedItems = new ISEquippable[capacity];
        for(int i=0; i< capacity; i++)
        {
            if(items[i] is null)
            {
                clonedItems[i] = null;
            }
            else
            {
                Item item = (Item)((ICloneable)items[i]).Clone();
                clonedItems[i] = (ISEquippable)item;
            }
        }
        return new Equipments(clonedItems);
    }

    public bool EquipItem(Item i)
    {
        if (i is ISEquippable)
        {
            ISEquippable equip = (ISEquippable)i;
            int index = GetIndexFromPart(equip.GetPartEquipped());
            return EquipItem(i, index);
        }
        return false;
    }
    public bool EquipItem(Item i,int index)
    {
        ISEquippable equip = (ISEquippable)i;
        List<BodyPartEquipped> parts = GetPartsFromIndex(index);
        if (parts.Contains(equip.GetPartEquipped())){
            foreach(Item item in GetItemsIfNewItemEquipped(i))
            {
                equip = (ISEquippable)item;
                for(int j=0; j< 10; j++)
                {
                    if (equip.Equals(items[j]))
                    {
                        items[j] = null;
                    }
                }
            }
            items[index] = (ISEquippable)i;
            return true;
            
        }
        return false;
    }

    private List<BodyPartEquipped> GetPartsFromIndex(int index)
    {
        List<BodyPartEquipped> parts = new List<BodyPartEquipped>();
        switch (index)
        {
            case 0:
                parts.Add(BodyPartEquipped.HEAD);
                break;
            case 1:
                parts.Add(BodyPartEquipped.NECK);
                break;
            case 2:
                parts.Add(BodyPartEquipped.TORSO);
                break;
            case 3:
                parts.Add(BodyPartEquipped.FINGERS);
                break;
            case 4:
                parts.Add(BodyPartEquipped.FINGERS);
                break;
            case 5:
                parts.Add(BodyPartEquipped.FINGERS);
                break;
            case 6:
                parts.Add(BodyPartEquipped.ONE_HAND);
                parts.Add(BodyPartEquipped.TWO_HAND);
                break;
            case 7:
                parts.Add(BodyPartEquipped.ONE_HAND);
                parts.Add(BodyPartEquipped.TWO_HAND);
                break;
            case 8:
                parts.Add(BodyPartEquipped.LEGS);
                break;
            case 9:
                parts.Add(BodyPartEquipped.FEET);
                break;
        }
        return parts;
    }

    private int GetIndexFromPart(BodyPartEquipped bodyPartEquipped)
    {
        switch (bodyPartEquipped)
        {
            case BodyPartEquipped.HEAD:
                return 0;
            case BodyPartEquipped.NECK:
                return 1;
            case BodyPartEquipped.TORSO:
                return 2;
            case BodyPartEquipped.FINGERS:
                for(int i = 3; i < 6; i++)
                {
                    if(items[i] is null)
                    {
                        return i;
                    }
                }
                return 3;
            case BodyPartEquipped.ONE_HAND:
                for(int i=6; i < 8; i++)
                {
                    if(TwoHandWeaponNotEquipped() && items[i] is null)
                    {
                        return i;
                    }
                }
                return 6;
            case BodyPartEquipped.TWO_HAND:
                return 6;
            case BodyPartEquipped.LEGS:
                return 8;
            case BodyPartEquipped.FEET:
                return 9;
        }
        throw new Exception();
    }

    private bool TwoHandWeaponNotEquipped()
    {
        return !(items[6] is null) && !(items[6].GetPartEquipped().Equals(BodyPartEquipped.TWO_HAND));
    }

    public List<Item> GetItemsIfNewItemEquipped(Item i)
    {
        List<Item> old = new List<Item>();
        ISEquippable equip = (ISEquippable)i;
        if(equip.GetPartEquipped().Equals(BodyPartEquipped.ONE_HAND) && items[6].GetPartEquipped().Equals(BodyPartEquipped.TWO_HAND))
        {
            old.Add((Item)items[GetIndexFromPart(BodyPartEquipped.TWO_HAND)]);
        }
        else if(equip.GetPartEquipped().Equals(BodyPartEquipped.TWO_HAND) && ((!(items[6] is null))) || (!(items[7] is null)))
        {
            if(!(items[6] is null))
            {
                old.Add((Item)items[6]);
                
            }
            if(!(items[7] is null))
            {
                old.Add((Item)items[7]);
            }
        }
        else if(!(items[GetIndexFromPart(equip.GetPartEquipped())] is null))
        {
            old.Add((Item)items[GetIndexFromPart(equip.GetPartEquipped())]);
        }
        return old;
    }
}