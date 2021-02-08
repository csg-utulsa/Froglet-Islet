using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Chase Clawson
 * Date Created: 02/03/2021
 * Last Modified Date: 02/03/2021
 * Last Modified By: 02/03/2021
 * Description: Data storage for saved player data
 */

public class PlayerPrefs : MonoBehaviour
{
    public List<string> CaughtFrogs = new List<string>();
    public List<string> AvailableActions = new List<string>();
    public List<string> Items = new List<string>();
}
