using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{

    public int slotsCount = 13;
    public List<Item> items;
    public Dictionary<string, int> itemStacks;

    void Awake()
    {
        items = new List<Item>(new Item[slotsCount]);
        itemStacks = new Dictionary<string, int>();
        items.Add(new Flute());
    }

    public bool AddItem(Item item)
    {
        foreach (string itemId in itemStacks.Keys)
        {
            if (item.id == itemId)
            {
                itemStacks[item.id]++;
                return true;
            }
        }

        int index = items.FindIndex(i => i.id == null);
        if (index != -1)
        {

            items[index] = item;
            itemStacks.Add(item.id, 1);
            return true;
        }

        return false;
    }

    public Item FindItem(string itemId)
    {
        int index = items.FindIndex(i => i != null && i.id == itemId);
        if (index >= 0)
        {
            return items[index];
        }
        return null;
    }

    public bool FindAndRemoveItem(string itemId)
    {
        foreach (string id in itemStacks.Keys)
        {
            if (itemId == id && itemStacks[id] > 1)
            {
                itemStacks[itemId]--;
                return true;
            }
        }

        int index = items.FindIndex(i => i != null && i.id == itemId);
        if (index >= 0)
        {
            items[index] = null;
            itemStacks.Remove(itemId);
            return true;
        }
        return false;
    }
}

