using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Item
{
    public Flute()
    {
        id = "FluteBase";
        name = "Flute";
        description = "The starter flute.";
        //icon = GET SPRITE FOR FLUTE HERE!
        itemType = ItemTypes.Flute;
    }
}
