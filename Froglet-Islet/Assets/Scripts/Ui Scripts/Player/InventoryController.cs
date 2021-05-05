using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{

    public int slotsCount = 24;
    public List<Item> items;
    public Dictionary<string, int> itemStacks;
    public InventoryScreen inventoryScreen;
    public GameScreen gameScreen;
    public List<FrogPen> frogPens;

    void Awake()
    {
        items = new List<Item>(new Item[slotsCount]);
        itemStacks = new Dictionary<string, int>();
        frogPens = FindObjectsOfType<FrogPen>().ToList();
    }

    public bool AddItem(Item item)
    {
        foreach (string itemId in itemStacks.Keys)
        {
            if (item.itemType == ItemTypes.Tool && item.id == itemId)
            {
                itemStacks[item.id]++;
                gameScreen.ShowMessage("Additional " + item.name + " obtained!");
                SoundFXController.Instance.Play(1);
                return true;
            }
            else if (item.itemType == ItemTypes.Frog && item.id == itemId)
            {
                foreach(FrogPen pen in frogPens)
                {
                    if (pen.SpawnFrog(item.name))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        int index = -1;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            items[index] = item;
            itemStacks.Add(item.id, 1);
<<<<<<< Updated upstream
            gameScreen.ShowMessage(item.name + " obtained!");
=======
            if (item.itemType == ItemTypes.Tool)
            {
                if (inventoryTutorialShown)
                {
                    gameScreen.ShowMessage(item.name + " obtained!");
                }
                else if (item.name == "Lantern" && !equipTutorialShown)
                {
                    gameScreen.ShowMessage(item.name + " obtained!\nYou can equip the lantern by\nclicking on it in your inventory.");
                    equipTutorialShown = true;
                }
                else
                {
                    gameScreen.ShowMessage(item.name + " obtained!\nPress I to open your inventory\nto see info on your tools and frogs.");
                    inventoryTutorialShown = true;
                }
            }
            else if (item.itemType == ItemTypes.Frog)
            {
                foreach (FrogPen pen in frogPens)
                {
                    if (pen.SpawnFrog(item.name))
                    {
                        return true;
                    }
                }
            }
            else if (item.itemType == ItemTypes.Flute)
            {
                foreach (Item inventoryItem in items)
                {
                    if (inventoryItem.itemType == ItemTypes.Flute && inventoryItem.id != item.id)
                    {
                        items.Remove(item);
                        itemStacks.Remove(inventoryItem.id);
                        break;
                    }
                }
                gameScreen.ShowMessage("Flute upgraded!\nNew Musical Notes are now available!");
            }
>>>>>>> Stashed changes
            SoundFXController.Instance.Play(1);
            return true;
        }

        return false;
    }

    /*
     * Find and return an item and its information in the inventory.
     */
    public Item FindItem(string itemId)
    {
        int index = items.FindIndex(i => i != null && i.id == itemId);
        if (index >= 0)
        {
            return items[index];
        }
        return null;
    }

    /*
     * Check if an item is in the inventory.
     */
    public bool CheckForItem(string itemId)
    {
        int index = items.FindIndex(i => i != null && i.id == itemId);
        if (index >= 0)
        {
            return true;
        }
        return false;
    }

    /*
     * Check if an item is in the inventory and consume it if it is.
     */
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

