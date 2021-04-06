using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{

    public int slotsCount = 13;
    public List<Item> items;
    public Dictionary<string, int> itemStacks;
    public InventoryScreen inventoryScreen;
    public GameScreen gameScreen;

    void Awake()
    {
        items = new List<Item>(new Item[slotsCount]);
        itemStacks = new Dictionary<string, int>();
        AddItem(new Flute());
    }

    public bool AddItem(Item item)
    {
        foreach (string itemId in itemStacks.Keys)
        {
            if (item.id == itemId)
            {
                itemStacks[item.id]++;
                gameScreen.ShowMessage("Additional " + item.name + " obtained!");
                return true;
            }
        }

        int index = items.FindIndex(i => i == null);
        if (index != -1)
        {

            items[index] = item;
            itemStacks.Add(item.id, 1);
            gameScreen.ShowMessage(item.name + " obtained!");
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

