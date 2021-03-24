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

    void Update()
    {
        if (GameController.gameState == GameController.GameStates.Game)
        {
            if (InputController.Item1) UseItemBySlot(0);
            if (InputController.Item2) UseItemBySlot(1);
            if (InputController.Item3) UseItemBySlot(2);
            if (InputController.Item4) UseItemBySlot(3);
            if (InputController.Item5) UseItemBySlot(4);
            if (InputController.Item6) UseItemBySlot(5);
        }
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

        int index = items.FindIndex(i => i == null);
        if (index != -1)
        {

            items[index] = item;
            itemStacks.Add(item.id, 1);
            return true;
        }

        return false;
    }

    public void UseItemBySlot(int slotId)
    {
        if (slotId < 0 || slotId > items.Count - 1 || items[slotId] == null) return;
        Item item = items[slotId];
        item.OnInteract();
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

    public bool FindAndUseItem(string itemId)
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

