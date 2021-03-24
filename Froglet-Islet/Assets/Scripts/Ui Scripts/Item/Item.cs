using UnityEngine;

[System.Serializable]
public class Item : IInteractable
{
    public enum ItemTypes
    {
        Frog = 0,
        Flute = 1,
        Tool = 2
    }

    public string id;
    public string name;
    public string description;
    public Sprite icon;
    public ItemTypes itemType;

    public virtual void OnInteract() { }
    public virtual void Deactivate() { }

    public Item() { }

    public override string ToString()
    {
        return name;
    }
}
