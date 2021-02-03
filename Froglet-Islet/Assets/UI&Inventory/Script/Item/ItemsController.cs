using System.Collections.Generic;

[System.Serializable]
public class ItemsController : Singleton<ItemsController>
{
    public List<ItemQuest> things = new List<ItemQuest>();

    public List<Item> Items
    {
        get
        {
            List<Item> list = new List<Item>();
            list.AddRange(things.ToArray());
            return list;
        }
    }

    public Item GetItemById(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;
        Item item = Items.Find(i => i.id == id);
        return item;
    }

    public void AddItem(Item.ItemTypes type)
    {
        if (type == Item.ItemTypes.Quest) things.Add(new ItemQuest());
    }

    public void RemoveItem(Item item)
    {
        if (item.itemType == Item.ItemTypes.Quest) things.Remove((ItemQuest)item);
    }
}
