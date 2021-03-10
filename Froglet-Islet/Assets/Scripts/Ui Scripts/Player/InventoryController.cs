using System.Collections.Generic;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{

    private List<Item> items;

    public int slotsCount = 23;
    public List<Item> Items { get { return items; } }

    void Awake()
    {
        items = new List<Item>(new Item[slotsCount]);
    }

    void Update()
    {
        
    }

    public bool AddItem(Item item)
    {
        int index = items.FindIndex(i => i == null);
        if (index == -1) return false;
        items[index] = item;
        return true;
    }


}

