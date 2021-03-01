using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Chase Clawson
 * Date Created: 02/03/2021
 * Last Modified Date: 02/08/2021
 * Last Modified By: Chase Clawson
 * Description: Data storage for saved player data
 */

public static class PlayerPrefs
{
    //List of frog names marked as caught
    public static List<Frog> CaughtFrogs = new List<Frog>();
    //List of actions the player has available (mostly determined by tools and similar items)
    public static List<string> AvailableActions = new List<string>();
    //List of items in the player's inventory
    public static List<string> Items = new List<string>();
}
