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
        if (GameController.gameState == GameController.GameStates.Game)
        {
            if (InputController.Item1) UseItem(0);
            if (InputController.Item2) UseItem(1);
            if (InputController.Item3) UseItem(2);
            if (InputController.Item4) UseItem(3);
            if (InputController.Item5) UseItem(4);
            if (InputController.Item6) UseItem(5);
        }
    }

    public bool AddItem(Item item)
    {
        int index = items.FindIndex(i => i == null);
        if (index == -1) return false;
        items[index] = item;
        return true;
    }


    public void UseItem(int slotId)
    {
        if (slotId < 0 || slotId > items.Count - 1) return;
        Item item = items[slotId];
        if (item == null || item.itemType == Item.ItemTypes.Quest) return;
        items[slotId] = null;
        item.Activate();
    }

    public bool FindAndUseItem(string itemId)
    {
        int index = Items.FindIndex(i => i != null && i.id == itemId);
        if (index >= 0)
        {
            Items[index] = null;
            return true;
        }
        return false;
    }

    public void Move(int firstSlot, int secondSlot)
    {
        if (firstSlot >= Items.Count || secondSlot >= Items.Count || firstSlot < 0 || secondSlot < 0) return;
        Item item = items[firstSlot];
        items[firstSlot] = items[secondSlot];
        items[secondSlot] = item;
    }
}

