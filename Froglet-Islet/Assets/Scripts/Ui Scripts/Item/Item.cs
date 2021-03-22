using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ItemTypes
    {
        Quest = 0, // Quest items
        Staff = 3,
    }

    public string id;
    public string name;
    public string description;
    public Sprite icon;
    public ItemTypes itemType;

    public virtual void Activate() { }
    public virtual void Deactivate() { }

    public Item() { }

    public override string ToString()
    {
        return name;
    }
}
