using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Item
{
    public Flute(Sprite sprite)
    {
        id = "FluteBase";
        name = "Flute";
        description = "The starter flute.";
        icon = sprite;
        itemType = ItemTypes.Flute;
    }
}
