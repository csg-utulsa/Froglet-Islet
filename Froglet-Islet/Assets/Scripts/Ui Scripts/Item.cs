using UnityEngine;
using UnityEngine.Events;

public enum ItemTypes
{
    Frog = 0,
    Flute = 1,
    Tool = 2
}

[System.Serializable]
public class Item
{
    public string id;
    public string name;
    public string description;
    public Sprite icon;
    public ItemTypes itemType;
    public UnityEvent itemFunction;

    public override string ToString()
    {
        return name;
    }
}
